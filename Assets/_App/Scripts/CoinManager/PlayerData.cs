using System;
using UnityEngine;

public class Constant
{
    public static string DataKey_PlayerData = "player_data";
    public static int countSong = 3;
    public static int priceUnlockSkin = 100;
}

public class PlayerData : BaseData
{
    public int helpCount;
    public int currentSkin;
    public bool[] listSkins;

    public Action<int> onChangeDiamond;

    public override void Init()
    {
        prefString = Constant.DataKey_PlayerData;
        if (PlayerPrefs.GetString(prefString).Equals(""))
        {
            ResetData();
        }

        base.Init();
    }


    public override void ResetData()
    {
        helpCount = 3;
        currentSkin = 0;
        listSkins = new bool[Constant.countSong];

        for (int i = 0; i < 1; i++)
        {
            listSkins[i] = true;
        }

        Save();
    }

    public bool CheckLock(int id)
    {
        return this.listSkins[id];
    }

    public void Unlock(int id)
    {
        if (!listSkins[id])
        {
            listSkins[id] = true;
        }

        Save();
    }

    public void AddHelp(int a)
    {
        helpCount += a;

        onChangeDiamond?.Invoke(helpCount);
        
        Save();
    }

    public bool CheckCanUnlock()
    {
        return helpCount >= Constant.priceUnlockSkin;
    }

    public void SubHelp(int a)
    {
        helpCount -= a;

        if (helpCount < 0)
        {
            helpCount = 0;
        }

        onChangeDiamond?.Invoke(helpCount);
        
        Save();
    }

    public void ChooseSong(int i)
    {
        currentSkin = i;
        Save();
    }
}