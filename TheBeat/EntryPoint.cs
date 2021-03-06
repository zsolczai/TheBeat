﻿using System;
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

[assembly: Rage.Attributes.Plugin("The Beat", Description = "Creates Ambient Events")]
namespace TheBeat
{
    public static class EntryPoint
    {
        private static Blip debugBlip1;
        private static Blip debugBlip2;

        private static List<Models.ScenarioData> scenarios = new List<Models.ScenarioData>();
        private static Models.ScenarioData closestScenario = new Models.ScenarioData();
        private static bool logicLoopShouldRun = false;
        public static void Main()
        {
            AssignScenarios();
            UpdateScenarios();
            StartLogic();
        }

        private static void AssignScenarios()
        {
            Models.ScenarioData fightScenarioData = new Models.ScenarioData();
            fightScenarioData.Name = "Fight Scenario";
            fightScenarioData.ChanceToActivate = 100;
            fightScenarioData.Position = new Vector3(2302.0f, 3071.0f, 0f);
            fightScenarioData.ActivateDistance = 100f;
            scenarios.Add(fightScenarioData);
            debugBlip1 = new Blip(fightScenarioData.Position, fightScenarioData.ActivateDistance);
            debugBlip1.Alpha = 0.5f;

            Models.ScenarioData loiteringScenarioData = new Models.ScenarioData();
            loiteringScenarioData.Name = "Loitering Scenario";
            loiteringScenarioData.ChanceToActivate = 100;
            loiteringScenarioData.Position = new Vector3(2325.0f, 3141.0f, 0f);
            loiteringScenarioData.ActivateDistance = 100f;
            debugBlip2 = new Blip(loiteringScenarioData.Position, loiteringScenarioData.ActivateDistance);
            debugBlip2.Alpha = 0.5f;

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
                Tuple<Models.ScenarioData, float> tuple = LocationHelper.SelectClosestScenarioToPlayer(scenarios);
                closestScenario = tuple.Item1;
                float scenarioDistanceToPlayer = tuple.Item2;
                if (scenarioDistanceToPlayer < closestScenario.ActivateDistance)
                {
                    logicLoopShouldRun = true;
                    StartLogic();
                }
                else
                {
                    logicLoopShouldRun = false;
                }
                GameFiber.Yield();
            }
        }

        private static void StartLogic()
        {
            while (logicLoopShouldRun)
            {
                GameFiber.Sleep(1000);
                if (closestScenario == null)
                {
                    continue;
                }

                if (LocationHelper.PlayerWithinLocation(50f, closestScenario.Position))
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
