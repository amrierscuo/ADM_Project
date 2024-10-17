using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderboardFunctions
{
    public class Gamers
    {
        public List<GamerSingle> gamerSingleList;
    }
    public class GamerSingle
    {
        public string name;
        public int TotAU;
        public int TotScoreD;
        public int numberGP;
        public int TotScoreR;
        public float rateo;
    }
} // gamerSingle.json contains the following code:
//{"gamerSingleList":[
//{"name":"player f","TotAU":100,"TotScoreD":10000,"numberGP":2,"TotScoreR":20000,"Rateo":2.0},
//{"name":"player b","TotAU":100,"TotScoreD":10000,"numberGP":2,"TotScoreR":20000,"Rateo":2.0}]}