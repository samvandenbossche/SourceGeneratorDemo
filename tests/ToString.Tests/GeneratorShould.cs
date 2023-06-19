using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using VerifyXunit;
using Xunit;

namespace ToString.Tests;

[UsesVerify]
public class GeneratorShould
{
    [Theory]
    [InlineData("AssemblyWithMultipleClasses")]
    [InlineData("AssemblyWithoutClassesWithToStringAttribute")]
    public Task GenererateToStringOverride(string sourceCodeFile)
    {
        var sourceCode = AssemblyHelper.GetStringFromResourceFileAsync($"{sourceCodeFile}.txt");
        var result = RunGenerator(sourceCode).Results[0].GeneratedSources;

        return Verifier.Verify(result)
            .UseParameters(sourceCodeFile);
    }

    private static GeneratorDriverRunResult RunGenerator(string sourceCode)
    {
        var compilation = CreateCompilation(sourceCode);
        GeneratorDriver driver = CSharpGeneratorDriver.Create(new ToStringGenerator());
        driver = driver.RunGeneratorsAndUpdateCompilation(compilation, out var _, out var _);

        return driver.GetRunResult();
    }

    private static Compilation CreateCompilation(string source)
        => CSharpCompilation.Create("compilation",
            new[] {CSharpSyntaxTree.ParseText(source)},
            new[] {MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location)},
            new CSharpCompilationOptions(OutputKind.ConsoleApplication));
}
