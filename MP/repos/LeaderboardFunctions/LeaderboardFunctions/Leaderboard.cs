using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderboardFunctions
{
    public class Leaderboard
    {
        public List<LeaderboardSingle> leaderboardSingleList;
    }
    public class LeaderboardSingle
    {
        public string name;//{get; set;}
        public int score;
    }
    //{"leaderboardSingleList":[{"name":"player a","score":56},{"name":"player b","score":12}]}
}
