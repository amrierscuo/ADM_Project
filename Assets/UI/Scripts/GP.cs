using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP 
{
    public List<GPSingle> gamesPlayedList;
}
public class GPSingle
{
        public string nameGame;
        public int gameScoreD;
        public int gameScoreR;
        public int numberAU;
        public float gameRateo;
        public int AOPTPTG;
}
//{"gamesPlayedList":[{"nameGame":"game a","gameScoreD":1000,"gameScoreR":2000,"numberAU":10,"gameRateo":2.0,"AOPTPTG":2},{"nameGame":"game b","gameScoreD":1000,"gameScoreR":2000,"numberAU":10,"gameRateo":2.0,"AOPTPTG":2}]}
