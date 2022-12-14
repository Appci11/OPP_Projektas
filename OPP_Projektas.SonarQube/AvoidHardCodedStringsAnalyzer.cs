using System.Collections.Immutable;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace OPP_Projektas.SonarQube;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class AvoidHardCodedStringsAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "AvoidHardCodedStrings01";

    private static readonly DiagnosticDescriptor Rule = new(
        DiagnosticId,
        "Avoid hardcoded strings",
        "Avoid using hardcoded strings in your code. Use string literals instead",
        "Code smell",
        DiagnosticSeverity.Warning,
        true);
        
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        
        context.RegisterSyntaxNodeAction(
            c =>
            {
                var stringLiteral = (LiteralExpressionSyntax) c.Node;
                var stringValue = stringLiteral.Token.ValueText;

                if (stringValue.Length >= 3 &&
                    !Regex.IsMatch(stringValue, "/.*\"(.*?)\"/") &&
                    !stringValue.StartsWith("Resources.", StringComparison.Ordinal))
                {
                    c.ReportDiagnostic(Diagnostic.Create(Rule, stringLiteral.GetLocation(), stringValue));
                }
            }, SyntaxKind.StringLiteralExpression);
    }

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);
}