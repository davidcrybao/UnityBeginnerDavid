using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ʱֻ�����ֵ�����-ʵ����û�н��  �Ժ��������� ���а�������� �����һ��
/// </summary>
public class GameDataManager
{
    //��Ϊû�м̳�MonoBehaviour�������ǿ���new
    private static GameDataManager instance = new GameDataManager();

    public static GameDataManager Instance => instance;

    private SettingData settingData;
    private PlayerRankData rankData;

    //��ֹ���ⲿ����
    private GameDataManager()
    {
        settingData = PlayerPrefsDataMgr.Instance.LoadData(typeof(SettingData), "Music") as SettingData;

        //����ǵ�һ�μ��� ȫ����ʼ��
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
        //�洢�ı�������
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public void OpenOrCloseSoundEffects(bool isOpen)
    {
        settingData.isSoundEffectsOpen = isOpen;
        //�洢�ı�������
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public void ChangeBGMValue(float value)
    {
        settingData.musicValue = value;
        //�洢�ı�������
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public void ChangeSoundEffectsValue(float value)
    {
        settingData.soundEffectsValue = value;
        //�洢�ı�������
        PlayerPrefsDataMgr.Instance.SaveData(settingData, "Music");
    }

    public List<PlayerData> GetPlayerData()
    { return rankData.playerDataList; }
}