using System.CodeDom;
using System.Configuration;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

namespace FeatureBaseClassGenerator.SpecFlowPlugin
{
    public class FeatureBaseClassGeneratorProvider : NUnit3TestGeneratorProvider
    {
        private readonly string _featureBaseClass;

        public FeatureBaseClassGeneratorProvider(CodeDomHelper codeDomHelper) : base(codeDomHelper)
        {
            _featureBaseClass = ConfigurationManager.AppSettings["SpecFlowFeatureBaseClass"];
        }

        public override void FinalizeTestClass(TestClassGenerationContext generationContext)
        {
            base.FinalizeTestClass(generationContext);
            var featureBaseClassTypeReference = new CodeTypeReference(_featureBaseClass);
            generationContext.TestClass.BaseTypes.Add(featureBaseClassTypeReference);
        }
    }
}