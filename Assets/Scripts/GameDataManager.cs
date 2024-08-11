using System.Collections;
using System.Collections.Generic;
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
            settingData.soundEffectsValue = 1f;
            settingData.musicValue = 1f;
            settingData.isBGMOpen = true;
            settingData.isSoundEffectsOpen = true;
           
        }

        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(PlayerRankData), "Rank") as PlayerRankData;

        
    }

    public void OpenOrCloseMusic(bool isOpen)
    {
        settingData.isBGMOpen = isOpen;
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public void OpenOrCloseSoundEffects(bool isOpen)
    {
        settingData.isSoundEffectsOpen = isOpen;
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public void ChangeBGMValue(float value)
    {
        settingData.musicValue = value;
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public void ChangeSoundEffectsValue(float value)
    {
        settingData.soundEffectsValue = value;
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }
}