using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using TheBeat.Models;

namespace TheBeat.Helpers
{
    class LocationHelper
    {
        public static Tuple<Models.ScenarioData, float>SelectClosestScenarioToPlayer(List<Models.ScenarioData> scenarios)
        {
            float distanceToPlayer = 100000f;
            Models.ScenarioData closestScenario = null;

            foreach (Models.ScenarioData scenario in scenarios)
            {
                if (closestScenario == null)
                {
                    closestScenario = scenario;
                    distanceToPlayer = Game.LocalPlayer.Character.Position.DistanceTo(scenario.Position);
                }
                else
                {
                    if (Game.LocalPlayer.Character.Position.DistanceTo(scenario.Position) < distanceToPlayer)
                    {
                        closestScenario = scenario;
                        distanceToPlayer = Game.LocalPlayer.Character.Position.DistanceTo(scenario.Position);
                    }
                }
            }
            return Tuple.Create(closestScenario, distanceToPlayer);
        }
        public static bool PlayerWithinLocation(float distanceFromLocation, Vector3 location)
        {
            if (Game.LocalPlayer.Character.Position.DistanceTo(location) <= distanceFromLocation)
            {
                return true;
            }
            return false;
        }
    }
}
