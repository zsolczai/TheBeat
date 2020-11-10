using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSPD_First_Response;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using Rage;

[assembly: Rage.Attributes.Plugin("The Beat Plugin", Description = "Creates Ambient Events")]
namespace TheBeat
{
    public static class EntryPoint //: Plugin
    {
        public static void Main()
        {
            Vector3 SpawnPoint = new Vector3(2325.0f, 3141.0f, 0f);

            while (true)
            {
                if (Helpers.LocationHelper.PlayerWithinLocation(50f, SpawnPoint))
                {
                    Game.DisplaySubtitle("Player entered location");
                }
                else
                {
                    Game.DisplaySubtitle("Player exited location");
                }
                Vector3 playerLocation = Game.LocalPlayer.Character.Position;
                //Game.DisplaySubtitle("location: "  + playerLocation);
                Rage.GameFiber.Yield();
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
