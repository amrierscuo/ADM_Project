using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Leaderboard
{
    public List<LeaderboardSingle> leaderboardSingleList;
}
public class LeaderboardSingle
{
    public string name;
    public int score;
}
//{ "leaderboardSingleList":[{ "name":"player a","score":56},{ "name":"player b","score":12}]}

