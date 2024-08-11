using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string name;
    public int time;
    public int score;

    public PlayerData()
    { }

    public PlayerData(string name, int time, int score)
    {
        this.name = name;
        this.time = time;
        this.score = score;
    }
}

public class PlayerRankData
{
    public List<PlayerData> playerDataDictionary;
}