using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace TheBeat.Models
{
    class Scenario
    {
        public enum State { running, idle }
        public string Name { get; set; }
        public int ChanceToActivate { get; set; }
        public Vector3 Position { get; set; }
        public float ActivateDistance { get; set; }
        public State state { get; set; }

    }
}
