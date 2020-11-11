using System;
using System.Collections.Generic;
using System.Linq;
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
        private static List<Scenario> scenarios = new List<Scenario>();
        private static Scenario closestScenario
        {
            get => closestScenario;
            set
            {
                closestScenario = value;
                Game.DisplaySubtitle("Closest scenario changed to: " + closestScenario.Name);
            }
        }
        public static void Main()
        {
            AssignScenarios();
            UpdateScenarios();

            while (true)
            {
                if (closestScenario == null)
                {
                    continue;
                }
                Game.LogTrivial("THE BEAT>>>> got to line 41");

                if (Helpers.LocationHelper.PlayerWithinLocation(50f, closestScenario.Position))
                {
                    Game.DisplaySubtitle("Player entered scenario: " + closestScenario.Name);
                }

                else
                {
                    Game.DisplaySubtitle("Player exited scenario: " + closestScenario.Name);
                }
                //GameFiber.Sleep(500);
                GameFiber.Yield();
            }
        }

        private static void AssignScenarios()
        {
            scenarios.Add(LoiteringScenario.InitScenario());
            scenarios.Add(FightingScenario.InitScenario());
            Game.LogTrivial("THE BEAT>>>> Scenario count is " + scenarios.Count);
        }

        private static void UpdateScenarios()
        {  
            while (true)
            {
                if (scenarios.Count == 0)
                {
                    continue;
                }
                Game.LogTrivial("THE BEAT>>>> line 72 Scenario count is " + scenarios.Count);
                closestScenario = LocationHelper.SelectClosestScenarioToPlayer(scenarios);
                //GameFiber.Sleep(3000);
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
