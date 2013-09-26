using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocketLauncher
{
    public class MissleLauncherEventArgs
    {
        public MissleLauncherEventArgs(MissleLauncher launcher)
        {
            MissleLauncher = launcher;
        }

        public MissleLauncher MissleLauncher { get; set; }
    }
}
