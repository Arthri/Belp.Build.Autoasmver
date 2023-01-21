﻿using Microsoft.CodeAnalysis.Testing;
using SGTest = Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests.CSharpIncrementalSourceGeneratorVerifier<Belp.CodeAnalysis.ManifestResourceGenerators.ManifestResourcesGenerator>.Test;

namespace Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests;

public partial class ManifestResourcesGenerator
{
    public partial class DiagnosticsTest
    {
        private class EmptyProjectNameTest : SGTest
        {
            protected override string DefaultTestProjectName => "";
        }

        [Fact]
        public Task When_AssemblyName_eq_nullX2C_then_expect_CS8203_and_MRG4001()
        {
            var test = new EmptyProjectNameTest
            {
                ReferenceAssemblies = ReferenceAssemblies.NetStandard.NetStandard20,

                TestState =
                {
                    ExpectedDiagnostics =
                    {
                        DiagnosticResult.CompilerError("CS8203"),
                        new DiagnosticResult(DiagnosticDescriptors.SourceGenerators.MRG4001),
                    },
                },
            };

            return test.RunAsync();
        }

        [Fact]
        public Task When_ResourceName_ends_with_X22X2EX22X2C_then_expect_MRGN4002()
        {
            var test = new SGTest
            {
                ReferenceAssemblies = ReferenceAssemblies.NetStandard.NetStandard20,

                TestState =
                {
                    AdditionalFiles =
                    {
                        ("/File.txt", ""),
                    },
                    AnalyzerConfigFiles =
                    {
                        ("/.editorconfig", """
                        [/File.txt]
                        build_metadata.AdditionalFiles.ManifestResourceName = File.txt.
                        build_metadata.AdditionalFiles.TargetSourceGenerator = ManifestResourcesGenerator
                        """),
                    },

                    ExpectedDiagnostics =
                    {
                        new DiagnosticResult(DiagnosticDescriptors.SourceGenerators.ManifestResourcesGenerator.MRGN4002),
                    },
                    GeneratedSources =
                    {
                        Source_ManifestResourcesHelper,
                    },
                },
            };

            return test.RunAsync();
        }
    }
}
