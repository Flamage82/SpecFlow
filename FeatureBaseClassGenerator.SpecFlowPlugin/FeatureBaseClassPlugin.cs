using BoDi;
using TechTalk.SpecFlow.Generator.Configuration;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;

namespace FeatureBaseClassGenerator.SpecFlowPlugin
{
    public class FeatureBaseClassPlugin : IGeneratorPlugin
    {
        public void RegisterDependencies(ObjectContainer container)
        {
        }

        public void RegisterCustomizations(ObjectContainer container, SpecFlowProjectConfiguration generatorConfiguration)
        {
            container.RegisterTypeAs<FeatureBaseClassGeneratorProvider, IUnitTestGeneratorProvider>("nunit");
        }

        public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration)
        {
        }
    }
}