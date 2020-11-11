using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LSPD_First_Response;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using Rage;
using TheBeat.Helpers;
using TheBeat.Models;
using TheBeat.ScenarioData;

[assembly: Rage.Attributes.Plugin("The Beat", Description = "Creates Ambient Events")]
namespace TheBeat
{
    public static class EntryPoint
    {
        private static List<Models.ScenarioData> scenarios = new List<Models.ScenarioData>();
        private static Models.ScenarioData closestScenario
        {
            get
            {
                return closestScenario;
            }
            set
            {
                closestScenario = value;
                StartLogic();
                Game.DisplaySubtitle("Closest scenario changed to: " + closestScenario.Name);
            }
        }
        public static void Main()
        {
            AssignScenarios();
            UpdateScenarios();
        }

        private static void AssignScenarios()
        {
            Models.ScenarioData fightScenario = new Models.ScenarioData();
            fightScenario.Name = "Fight Scenario";
            fightScenario.ChanceToActivate = 100;
            fightScenario.Position = new Vector3(2302.0f, 3071.0f, 0f);
            fightScenario.ActivateDistance = 100f;
            scenarios.Add(fightScenario);

            Models.ScenarioData loiteringScenarioData = new Models.ScenarioData();
            loiteringScenarioData.Name = "Loitering Scenario";
            loiteringScenarioData.ChanceToActivate = 100;
            loiteringScenarioData.Position = new Vector3(2325.0f, 3141.0f, 0f);
            loiteringScenarioData.ActivateDistance = 100f;
            scenarios.Add(loiteringScenarioData);
        }

        private static void UpdateScenarios()
        {
            while (true)
            {
                GameFiber.Sleep(500);
                if (scenarios.Count == 0)
                {
                    continue;
                }
                Game.LogTrivial(">>>> line 72 Scenario count is " + scenarios.Count);
                Game.LogTrivial(">>>> line 74 Scenario name is: " + scenarios[0].Name);
                //closestScenario = scenarios.First();
                //closestScenario = LocationHelper.SelectClosestScenarioToPlayer(scenarios);
                GameFiber.Yield();
            }
        }

        private static void StartLogic()
        {
            while (true)
            {
                GameFiber.Sleep(1000);
                if (closestScenario == null)
                {
                    Game.LogTrivial(">>>> got to line 65 continue while");
                    continue;
                }
                Game.LogTrivial(">>>> got to line 68");

                if (Helpers.LocationHelper.PlayerWithinLocation(50f, closestScenario.Position))
                {
                    Game.DisplaySubtitle("Player entered scenario: " + closestScenario.Name);
                }

                else
                {
                    Game.DisplaySubtitle("Player exited scenario: " + closestScenario.Name);
                }
                GameFiber.Yield();
            }
        }

        ///// <summary>
        ///// This method is run when the plugin is first initialized.
        ///// </summary>
        //public override void Initialize()
        //{
        //    //Subscribe to the OnOnDutyStateChanged event, so we don't register our callouts unless the player is on duty.
        //    Functions.OnOnDutyStateChanged += this.OnDutyStateChangedEvent;

        //    //Logging is a great tool, so we log to make sure the plugins loaded.
        //    Game.LogTrivial("----> TheBeat initialized");
        //}

        ///// <summary>
        ///// Called when the OnOnDutyStateChanged event is raised.        
        //public void OnDutyStateChangedEvent(bool onDuty)
        //{
        //    //If the player is going on duty, register the callout.
        //    if (onDuty)
        //    {

        //    }
        //}

        ///// <summary>
        ///// Called before the plugin is unloaded.
        ///// </summary>
        //public override void Finally()
        //{
        //    Game.LogTrivial("----> TheBeat unloaded");
        //}
    }
}
