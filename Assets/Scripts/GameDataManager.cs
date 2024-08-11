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
}