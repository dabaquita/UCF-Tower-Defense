using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class User
{
    protected string username;
    protected int currentLevel;
    protected int highestWave;
    protected Dictionary<string, bool> unlockedMaps;
    protected int xp;

    public User(string name, int level, int highestWave, Dictionary<string, bool> maps, int xp)
    {
        this.username = name;
        this.currentLevel = level;
        this.highestWave = highestWave;
        this.unlockedMaps = maps;
        this.xp = xp;
    }

    public string getUsername()
    {
        return this.username;
    }

    public int getCurrentLevel()
    {
        return this.currentLevel;
    }

    public int getHighestWave()
    {
        return this.highestWave;
    }

    public bool mapIsUnlocked(MapName name)
    {
        try
        {
            bool isUnlocked = false;
            return this.unlockedMaps.TryGetValue(name.Value, out isUnlocked);
        }
        catch
        {
            return false;
        }
    }

    public int getXP()
    {
        return this.xp;
    }


}
