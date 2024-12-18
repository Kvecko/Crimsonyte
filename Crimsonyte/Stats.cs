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
        public static int room;

        //Player things
        public static string playerName { get; set; }
        public static int playerHP;
        public static bool usedAttack = false;
        public static int money = 0;
        public static int attackLevel = 0;
        public static int healLevel = 0;

        //Enemy things
        public static int enemyHP;
        public static int enemyDMGMin;
        public static int enemyDMGMax;
    }
}
