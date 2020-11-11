using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using TheBeat.Models;

namespace TheBeat.ScenarioData
{
    class LoiteringScenario
    {
        public static Scenario InitScenario()
        {
            Scenario scenario = new Scenario();
            scenario.Name = "Loitering Around Building";
            scenario.ChanceToActivate = 100;
            scenario.Position = new Vector3(2325.0f, 3141.0f, 0f);
            scenario.ActivateDistance = 100f;
            scenario.state = Scenario.State.idle;
            return scenario;
        }
    }
}
