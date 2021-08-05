using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSolutionComparer.Utilities
{
    public class SolutionSelectedEventArgs : EventArgs
    {
        public SolutionSelectedEventArgs(Entity solution)
        {
            Solution = solution;
        }

        public Entity Solution { get; private set; }
    }
}