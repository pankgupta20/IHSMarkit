using TechTalk.SpecFlow;

namespace TestProject.UITest.Steps
{
    [Binding]
    public class Binding
    {
        private ScenarioContext _scenarioContext;

        public Binding(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
