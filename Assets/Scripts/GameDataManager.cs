using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

/// <summary>
/// 暂时只有音乐的数据-实际是没有结合  以后会增加玩家 排行榜类的数据 结合在一起
/// </summary>
public class GameDataManager
{
    //因为没有继承MonoBehaviour所以咱们可以new
    private static GameDataManager instance = new GameDataManager();

    public static GameDataManager Instance => instance;

    private SettingData settingData;
    private PlayerRankData rankData;

    //禁止被外部调用
    private GameDataManager()
    {
        settingData = PlayerPrefsDataMgr.Instance.LoadData(typeof(SettingData), "Music") as SettingData;

        //如果是第一次加载 全部初始化
        if (!settingData.hasLoadedBefore)
        {
            settingData.hasLoadedBefore = true;
            settingData.MusicEffectsValue = 1f;
            settingData.musicValue = 1f;
            settingData.isBGMOpen = true;
            settingData.isSMusicEffectsOpen = true;
        }

        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(PlayerRankData), "Rank") as PlayerRankData;
    }

    public void AddRankInfo(string name, int score, float time)
    {
        rankData.playerDataList.Add(new PlayerData(name, time, score));
        rankData.playerDataList.Sort((a, b) => a.time < b.time ? -1 : 1);

        /*for (int i = rankData.playerDataList.Count-1; i >= 10; i++)
        {
            rankData.playerDataList.RemoveAt(i);
        }
*/
        if (rankData.playerDataList.Count >= 10)
        {
            rankData.playerDataList.RemoveRange(10, rankData.playerDataList.Count - 10);
        }

        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }

    public void OpenOrCloseMusic(bool isOpen)
    {
        settingData.isBGMOpen = isOpen;
        AudioController.Instance.OpenMusic(isOpen);
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public void OpenOrCloseSoundEffects(bool isOpen)
    {
        settingData.isSMusicEffectsOpen = isOpen;
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public void ChangeBGMValue(float value)
    {
        settingData.musicValue = value;
        AudioController.Instance.ChangeValue(value);
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public void ChangeSoundEffectsValue(float value)
    {
        settingData.MusicEffectsValue = value;
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public List<PlayerData> GetPlayerData()
    { return rankData.playerDataList; }

    internal SettingData GetSettingData()
    {
        return settingData;
    }
}