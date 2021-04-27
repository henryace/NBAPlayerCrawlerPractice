using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_Crawler.Model
{
    class Player
    {
        // https://www.basketball-reference.com/players/a/abdelal01.html

        public int G { get; set; }
        public float PTS { get; set; }
        public float TRB { get; set; }

        public float AST { get; set; }
        public float FG { get; set; }
        public float FG3 { get; set; }

        public float FT { get; set; }
        public float eFG { get; set; }
        public float PER { get; set; }

        public float WS { get; set; }

        public string playerName { get; set; }
        public string url { get; set; }


        public Player(string name)
        {
            playerName = name;

        }
    }
}
