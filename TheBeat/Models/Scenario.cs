using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace TheBeat.Models
{
    public class Scenario
    {
        public Scenario(ScenarioData scenarioData)
        {
            this.ScenarioData = scenarioData;
        }
        public ScenarioData ScenarioData { get; set; }
    }

}
