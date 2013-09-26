using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLauncher
{
    public  class Commands
    {
        public static byte[] CMD = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 2 };

        public static byte[] UP1 = new byte[] { 0, 2, 2, 0, 0, 0, 0, 0, 0};

        public static byte[] DOWN1 = new byte[] { 0, 2, 1, 0, 0, 0, 0, 0, 0 };

        public static byte[] LEFT1 = new byte[] { 0, 2, 4, 0, 0, 0, 0, 0, 0};

        public static byte[] RIGHT1 = new byte[] { 0, 2, 8, 0, 0, 0, 0, 0, 0 };

        public static byte[] FIRE1 = new byte[] { 0, 2, 16, 0, 0, 0, 0, 0, 0 };

        public static byte[] STOP1 = new byte[] { 0, 2, 32, 0, 0, 0, 0, 0, 0 };

        public static byte[] GET_STATUS1 = new byte[] { 0, 1, 0, 0, 0, 0, 0, 0, 0 };

        public static byte[] LED_ON = new byte[] { 0, 3, 1, 0, 0, 0, 0, 0, 0 };

        public static byte[] LED_OFF = new byte[] { 0, 3, 0, 0, 0, 0, 0, 0, 0 };
    }
}
