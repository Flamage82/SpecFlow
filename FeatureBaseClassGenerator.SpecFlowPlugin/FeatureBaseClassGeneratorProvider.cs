using System.CodeDom;
using System.IO;
using System.Xml;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.Interfaces;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

namespace FeatureBaseClassGenerator.SpecFlowPlugin
{
    public class FeatureBaseClassGeneratorProvider : NUnit3TestGeneratorProvider
    {
        private readonly ProjectSettings _projectSettings;
        private readonly string _featureBaseClass;

        public FeatureBaseClassGeneratorProvider(CodeDomHelper codeDomHelper, ProjectSettings projectSettings) : base(codeDomHelper)
        {
            _projectSettings = projectSettings;
            _featureBaseClass = GetAppSetting("SpecFlowFeatureBaseClass");
        }

        public override void FinalizeTestClass(TestClassGenerationContext generationContext)
        {
            base.FinalizeTestClass(generationContext);
            var featureBaseClassTypeReference = new CodeTypeReference(_featureBaseClass);
            generationContext.TestClass.BaseTypes.Add(featureBaseClassTypeReference);
        }

        private string GetAppSetting(string key)
        {
            var configXml = new XmlDocument();
            configXml.Load(Path.Combine(_projectSettings.ProjectFolder, "App.config"));
            var settingValue = configXml.DocumentElement.SelectSingleNode(string.Format("/configuration/appSettings/add[@key='{0}']", key)).Attributes["value"].Value;
            return settingValue;
        }
    }
}