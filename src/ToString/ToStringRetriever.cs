using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace ToString
{
    internal class ToStringReceiver : ISyntaxReceiver
    {
        private const string AttributeShort = "ToString"; // without "Attribute" suffix
        private readonly List<ClassDeclarationSyntax> _candidates = new List<ClassDeclarationSyntax>();

        public IEnumerable<ClassDeclarationSyntax> Candidates => _candidates;

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classSyntax && classSyntax.HasAttribute(AttributeShort))
            {
                _candidates.Add(classSyntax);
            }
        }
    }
}
