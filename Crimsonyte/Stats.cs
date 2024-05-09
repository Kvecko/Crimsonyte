using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Crimsonyte
{
    internal class Stats
    {
        //Game values
        public static Random rng = new Random();
        public static int value;
        public static int wave = 1;

        //Player things
        public static string playerName { get; set; }
        public static int playerHP = 150;
        public static bool usedAttack = false;

        //Enemy things
        public static int enemyHP;
        public static int enemyDMGMin;
        public static int enemyDMGMax;
    }
}
