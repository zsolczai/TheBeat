﻿using System;
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
        public static Scenario SelectClosestScenarioToPlayer(List<Scenario> scenarios)
        {
            float distanceToPlayer = 0f;
            Scenario closestScenario = null;

            foreach (Scenario scenario in scenarios)
            {
                if (scenario == null)
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
            Game.LogTrivial("THE BEAT>>>> LocationHelper line 34: " + closestScenario.Name);

            return closestScenario;
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
