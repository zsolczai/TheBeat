using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSPD_First_Response;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using Rage;

namespace TheBeat
{
    public class EntryPoint : Plugin
    {
        /// <summary>
        /// This method is run when the plugin is first initialized.
        /// </summary>
        public override void Initialize()
        {
            //Subscribe to the OnOnDutyStateChanged event, so we don't register our callouts unless the player is on duty.
            Functions.OnOnDutyStateChanged += this.OnDutyStateChangedEvent;

            //Logging is a great tool, so we log to make sure the plugins loaded.
            Game.LogTrivial("----> TheBeat initialized");
        }

        /// <summary>
        /// Called when the OnOnDutyStateChanged event is raised.        
        public void OnDutyStateChangedEvent(bool onDuty)
        {
            //If the player is going on duty, register the callout.
            if (onDuty)
            {
                
            }
        }

        /// <summary>
        /// Called before the plugin is unloaded.
        /// </summary>
        public override void Finally()
        {
            Game.LogTrivial("----> TheBeat unloaded");
        }
    }
}
