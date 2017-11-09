﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

using AtlusScriptLib.Common.Logging;
using AtlusScriptLib.FlowScriptLanguage.Syntax;

namespace AtlusScriptLib.FlowScriptLanguage.Compiler.Processing
{
    public class FlowScriptTypeResolver
    {
        private Logger mLogger;
        private Stack<FlowScriptDeclarationScope> mScopes;
        private FlowScriptDeclarationScope mRootScope;

        private FlowScriptDeclarationScope Scope => mScopes.Peek();

        /// <summary>
        /// Initializes a FlowScript type resolver with a default configuration.
        /// </summary>
        public FlowScriptTypeResolver()
        {
            mLogger = new Logger( nameof( FlowScriptTypeResolver ) );
            mScopes = new Stack<FlowScriptDeclarationScope>();
        }

        /// <summary>
        /// Adds a resolver log listener. Use this if you want to see what went wrong during resolving.
        /// </summary>
        /// <param name="listener">The listener to add.</param>
        public void AddListener( LogListener listener )
        {
            listener.Subscribe( mLogger );
        }

        /// <summary>
        /// Try to resolve expression types in the given compilation unit.
        /// </summary>
        /// <param name="compilationUnit"></param>
        /// <returns></returns>
        public bool TryResolveTypes( FlowScriptCompilationUnit compilationUnit )
        {
            LogInfo( "Resolving types in compilation unit" );

            if ( !TryResolveTypesInCompilationUnit( compilationUnit ) )
                return false;

            LogInfo( "Done resolving types in compilation unit" );

            return true;
        }

        //
        // Registering declarations
        //
        private bool TryRegisterTopLevelDeclarations( FlowScriptCompilationUnit compilationUnit )
        {
            LogTrace(  "Registering/forward-declaring top level declarations" );

            if ( !TryRegisterDeclarations( compilationUnit.Declarations ) )
                return false;

            return true;
        }

        private bool TryRegisterDeclarations( IEnumerable<FlowScriptStatement> statements )
        {
            foreach ( var statement in statements )
            {
                if ( statement is FlowScriptDeclaration declaration )
                {
                    if ( !TryRegisterDeclaration( declaration ) )
                        return false;
                }
            }

            return true;
        }

        private bool TryRegisterDeclaration( FlowScriptDeclaration declaration )
        {
            if ( !Scope.TryRegisterDeclaration( declaration ) )
            {
                // Special case: forward declared declarations on top level
                if ( Scope.Parent != null )
                    return false;
            }

            return true;
        }

        //
        // Type resolving
        //
        private bool TryResolveTypesInCompilationUnit( FlowScriptCompilationUnit compilationUnit )
        {
            // Enter compilation unit scope
            PushScope();

            // Top level declarations are handled seperately to make them accessible throughout the entire file
            // regardless of scope
            if ( !TryRegisterTopLevelDeclarations( compilationUnit ) )
                return false;

            foreach ( var statement in compilationUnit.Declarations )
            {
                if ( !TryResolveTypesInStatement( statement ) )
                    return false;
            }

            // Exit compilation unit scope
            PopScope();

            return true;
        }

        // Statements
        private bool TryResolveTypesInStatement( FlowScriptStatement statement )
        {
            if ( statement is FlowScriptCompoundStatement compoundStatement )
            {
                if ( !TryResolveTypesInCompoundStatement( compoundStatement ) )
                    return false;
            }
            else if ( statement is FlowScriptDeclaration declaration )
            {
                if ( !TryRegisterDeclaration( declaration ) )
                    return false;

                if ( !TryResolveTypesInDeclaration( declaration ) )
                    return false;
            }
            else if ( statement is FlowScriptExpression expression )
            {
                if ( !TryResolveTypesInExpression( expression ) )
                    return false;
            }
            else if ( statement is FlowScriptIfStatement ifStatement )
            {
                if ( !TryResolveTypesInIfStatement( ifStatement ) )
                    return false;
            }
            else if ( statement is FlowScriptForStatement forStatement )
            {
                if ( !TryResolveTypesInForStatement( forStatement ) )
                    return false;
            }
            else if ( statement is FlowScriptWhileStatement whileStatement )
            {
                if ( !TryResolveTypesInWhileStatement( whileStatement ) )
                    return false;
            }
            else if ( statement is FlowScriptReturnStatement returnStatement )
            {
                if ( returnStatement.Value != null )
                {
                    if ( !TryResolveTypesInExpression( returnStatement.Value ) )
                        return false;
                }
            }
            else if ( statement is FlowScriptGotoStatement gotoStatement )
            {
                gotoStatement.LabelIdentifier.ExpressionValueType = FlowScriptValueType.Label;
            }
            else if ( statement is FlowScriptSwitchStatement switchStatement )
            {
                if ( !TryResolveTypesInSwitchStatement( switchStatement ) )
                    return false;
            }
            else
            {
                LogWarning( $"No types resolved in statement '{statement}'" );
                //return false;
            }

            return true;
        }

        private bool TryResolveTypesInCompoundStatement( FlowScriptCompoundStatement compoundStatement )
        {
            PushScope();

            foreach ( var statement in compoundStatement )
            {
                if ( !TryResolveTypesInStatement( statement ) )
                    return false;
            }

            PopScope();

            return true;
        }

        private bool TryResolveTypesInDeclaration( FlowScriptDeclaration declaration )
        {
            if ( declaration.DeclarationType != FlowScriptDeclarationType.Label )
            {
                if ( !TryResolveTypesInIdentifier( declaration.Identifier ) )
                {
                    LogError( declaration.Identifier, $"Failed to resolve types in declaration identifier: {declaration.Identifier}" );
                    return false;
                }
            }
            else
            {
                declaration.Identifier.ExpressionValueType = FlowScriptValueType.Label;
            }

            if ( declaration is FlowScriptProcedureDeclaration procedureDeclaration )
            {
                if ( !TryResolveTypesInProcedureDeclaration( procedureDeclaration ) )
                {
                    LogError( procedureDeclaration, $"Failed to resolve types in procedure declaration: {procedureDeclaration}" );
                    return false;
                }
            }
            else if ( declaration is FlowScriptVariableDeclaration variableDeclaration )
            {
                if ( !TryResolveTypesInVariableDeclaration( variableDeclaration ) )
                {
                    LogError( variableDeclaration, $"Failed to resolve types in variable declaration: {variableDeclaration}" );
                    return false;
                }
            }

            return true;
        }

        internal bool TryResolveTypesInExpression( FlowScriptExpression expression )
        {
            LogTrace( expression, $"Resolving expression {expression}" );

            if ( expression is FlowScriptMemberAccessExpression memberAccessExpression )
            {
                expression.ExpressionValueType = FlowScriptValueType.Int; // enum
            }
            else if ( expression is FlowScriptCallOperator callExpression )
            {
                if ( !TryResolveTypesInCallExpression( callExpression ) )
                    return false;
            }
            else if ( expression is FlowScriptUnaryExpression unaryExpression )
            {
                if ( !TryResolveTypesInExpression( unaryExpression.Operand ) )
                    return false;

                unaryExpression.ExpressionValueType = unaryExpression.Operand.ExpressionValueType;
            }
            else if ( expression is FlowScriptBinaryExpression binaryExpression )
            {
                if ( !TryResolveTypesInExpression( binaryExpression.Left ) )
                    return false;

                if ( !TryResolveTypesInExpression( binaryExpression.Right ) )
                    return false;

                if ( !( expression is FlowScriptEqualityOperator || expression is FlowScriptNonEqualityOperator ||
                     expression is FlowScriptGreaterThanOperator || expression is FlowScriptGreaterThanOrEqualOperator ||
                     expression is FlowScriptLessThanOperator || expression is FlowScriptLessThanOrEqualOperator ||
                     expression is FlowScriptLogicalAndOperator || expression is FlowScriptLogicalOrOperator ) )
                {
                    binaryExpression.ExpressionValueType = binaryExpression.Left.ExpressionValueType;
                }
            }
            else if ( expression is FlowScriptIdentifier identifier )
            {
                if ( !TryResolveTypesInIdentifier( identifier ) )
                    return false;
            }
            else
            {
                if ( expression.ExpressionValueType == FlowScriptValueType.Unresolved )
                {
                    LogError( expression, $"Unresolved expression: {expression}" );
                    return false;
                }
            }

            LogTrace( expression, $"Resolved expression {expression} to type {expression.ExpressionValueType}" );

            return true;
        }

        private bool TryResolveTypesInIfStatement( FlowScriptIfStatement ifStatement )
        {
            if ( !TryResolveTypesInExpression( ifStatement.Condition ) )
                return false;

            if ( !TryResolveTypesInCompoundStatement( ifStatement.Body ) )
                return false;

            if ( ifStatement.ElseBody != null )
            {
                if ( !TryResolveTypesInCompoundStatement( ifStatement.ElseBody ) )
                    return false;
            }

            return true;
        }

        private bool TryResolveTypesInForStatement( FlowScriptForStatement forStatement )
        {
            // Enter for scope
            PushScope();

            // For loop Initializer
            if ( !TryResolveTypesInStatement( forStatement.Initializer ) )
                return false;

            // For loop Condition
            if ( !TryResolveTypesInExpression( forStatement.Condition ) )
                return false;

            // For loop After loop expression
            if ( !TryResolveTypesInExpression( forStatement.AfterLoop ) )
                return false;

            // For loop Body
            if ( !TryResolveTypesInCompoundStatement( forStatement.Body ) )
                return false;

            // Exit for scope
            PopScope();

            return true;
        }

        private bool TryResolveTypesInWhileStatement( FlowScriptWhileStatement whileStatement )
        {
            // Resolve types in while statement condition
            if ( !TryResolveTypesInExpression( whileStatement.Condition ) )
                return false;

            // Resolve types in body
            if ( !TryResolveTypesInCompoundStatement( whileStatement.Body ) )
                return false;

            return true;
        }

        private bool TryResolveTypesInSwitchStatement( FlowScriptSwitchStatement switchStatement )
        {
            if ( !TryResolveTypesInExpression( switchStatement.SwitchOn ) )
                return false;

            foreach ( var label in switchStatement.Labels )
            {
                if ( label is FlowScriptConditionSwitchLabel conditionLabel )
                {
                    if ( !TryResolveTypesInExpression( conditionLabel.Condition ) )
                        return false;
                }

                foreach ( var statement in label.Body )
                {
                    if ( !TryResolveTypesInStatement( statement ) )
                        return false;
                }
            }

            return true;
        }

        // Declarations
        private bool TryResolveTypesInProcedureDeclaration( FlowScriptProcedureDeclaration declaration )
        {
            LogInfo( declaration, $"Resolving types in procedure '{declaration.Identifier.Text}'" );

            // Nothing to resolve if there's no body
            if ( declaration.Body == null )
                return true;

            // Enter procedure body scope
            PushScope();

            foreach ( var parameter in declaration.Parameters )
            {
                var parameterDeclaration = new FlowScriptVariableDeclaration(
                    new FlowScriptVariableModifier( FlowScriptModifierType.Local ),
                    parameter.Type,
                    parameter.Identifier,
                    null );

                if ( !TryRegisterDeclaration( parameterDeclaration ) )
                {
                    LogError( parameter, "Failed to register declaration for procedure parameter" );
                    return false;
                }
            }

            if ( !TryResolveTypesInCompoundStatement( declaration.Body ) )
                return false;

            // Exit procedure body scope
            PopScope();

            return true;
        }

        private bool TryResolveTypesInVariableDeclaration( FlowScriptVariableDeclaration declaration )
        {
            // Nothing to resolve if there's no initializer
            if ( declaration.Initializer == null )
                return true;

            if ( !TryResolveTypesInExpression( declaration.Initializer ) )
            {
                LogError( declaration.Initializer, $"Failed to resolve types in variable initializer expression: {declaration.Initializer}" );
                return false;
            }

            return true;
        }

        // Expressions

        private bool TryResolveTypesInCallExpression( FlowScriptCallOperator callExpression )
        {
            if ( !Scope.TryGetDeclaration( callExpression.Identifier, out var declaration ) )
            {
                // Disable for now because we import functions at compile time
                //LogWarning( callExpression, $"Call expression references undeclared identifier '{callExpression.Identifier.Text}'" );
            }

            if ( declaration is FlowScriptFunctionDeclaration functionDeclaration )
            {
                callExpression.ExpressionValueType = functionDeclaration.ReturnType.ValueType;
                callExpression.Identifier.ExpressionValueType = FlowScriptValueType.Function;
            }
            else if ( declaration is FlowScriptProcedureDeclaration procedureDeclaration )
            {
                callExpression.ExpressionValueType = procedureDeclaration.ReturnType.ValueType;
                callExpression.Identifier.ExpressionValueType = FlowScriptValueType.Procedure;
            }
            else
            {
                // Disable for now because we import functions at compile time
                //LogWarning( callExpression, "Expected function or procedure identifier" );
                //return false;
            }

            foreach ( var arg in callExpression.Arguments )
            {
                if ( !TryResolveTypesInExpression( arg ) )
                    return false;
            }

            return true;
        }

        private bool TryResolveTypesInIdentifier( FlowScriptIdentifier identifier )
        {
            if ( !Scope.TryGetDeclaration( identifier, out var declaration ) )
            {
                LogWarning( identifier, $"Identifiers references undeclared identifier '{identifier.Text}'" );
            }

            if ( declaration is FlowScriptFunctionDeclaration functionDeclaration )
            {
                identifier.ExpressionValueType = FlowScriptValueType.Function;
            }
            else if ( declaration is FlowScriptProcedureDeclaration procedureDeclaration )
            {
                identifier.ExpressionValueType = FlowScriptValueType.Procedure;
            }
            else if ( declaration is FlowScriptVariableDeclaration variableDeclaration )
            {
                identifier.ExpressionValueType = variableDeclaration.Type.ValueType;
            }
            else if ( declaration is FlowScriptLabelDeclaration labelDeclaration )
            {
                identifier.ExpressionValueType = FlowScriptValueType.Label;
            }
            else
            {
                LogWarning( identifier, "Expected function, procedure, variable or label identifier" );
            }

            return true;
        }

        //
        // Scope
        //
        private void PushScope()
        {
            if ( mScopes.Count != 0 )
            {
                mScopes.Push( new FlowScriptDeclarationScope( Scope ) );
            }
            else
            {
                mRootScope = new FlowScriptDeclarationScope( null );
                mScopes.Push( mRootScope );
            }
        }

        private void PopScope()
        {
            mScopes.Pop();
        }

        //
        // Logging
        //
        private void LogTrace( FlowScriptSyntaxNode node, string message )
        {
            if ( node.SourceInfo != null )
                LogTrace( $"({node.SourceInfo.Line:D4}:{node.SourceInfo.Column:D4}) {message}" );
            else
                LogTrace( message );
        }

        private void LogTrace( string message )
        {
            mLogger.Trace( $"{message}" );
        }

        private void LogInfo( string message )
        {
            mLogger.Info( $"{message}" );
        }

        private void LogInfo( FlowScriptSyntaxNode node, string message )
        {
            mLogger.Info( $"({node.SourceInfo.Line:D4}:{node.SourceInfo.Column:D4}) {message}" );
        }

        private void LogError( FlowScriptSyntaxNode node, string message )
        {
            if ( node.SourceInfo != null )
                LogError( $"({node.SourceInfo.Line:D4}:{node.SourceInfo.Column:D4}) {message}" );
            else
                LogError( message );

            if ( Debugger.IsAttached )
                Debugger.Break();
        }

        private void LogError( string message )
        {
            mLogger.Error( $"{message}" );
        }

        private void LogWarning( string message )
        {
            mLogger.Warning( $"{message}" );
        }

        private void LogWarning( FlowScriptSyntaxNode node, string message )
        {
            mLogger.Warning( $"({node.SourceInfo.Line:D4}:{node.SourceInfo.Column:D4}) {message}" );
        }
    }
}
