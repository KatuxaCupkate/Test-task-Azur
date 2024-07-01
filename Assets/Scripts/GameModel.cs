using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel
{
    public List<Difference> Differences { get; private set; }
    public int GameTime { get; private set; }


    public GameModel(Difference []differenceToAdd, int gameTime = 60)
    {
        Differences = new List<Difference>();
        foreach (var difference in differenceToAdd)
        {
            Differences.Add(difference);
        }
        GameTime = gameTime;
    }
}
