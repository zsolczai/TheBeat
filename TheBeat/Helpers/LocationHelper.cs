using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace TheBeat.Helpers
{
    class LocationHelper
    {
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
