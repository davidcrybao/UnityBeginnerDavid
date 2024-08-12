using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BasePanel<SettingPanel>
{
    [SerializeField] private CustomGUIButton quitButton;
    [SerializeField] private CustomGUIToggle musicToggle;
    [SerializeField] private CustomGUIToggle musicEffectsToggle;
    [SerializeField] private CustomGUISlider musicValue;
    [SerializeField] private CustomGUISlider musicEffectsValue;

    [SerializeField] private bool isGameScene = false;
    private new void Awake()
    {
        base.Awake(); 
        print("dedesd");
    }
    private void Start()
    {
      
        quitButton.clickEvent += QuitButton_clickEvent;
        musicToggle.changeValue += MusicToggle_changeValue;
        musicEffectsToggle.changeValue+=MusicEffectsToggle_changeValue;
        musicValue.changeValue += MusicValue_changeValue;
        musicEffectsValue.changeValue += MusicEffectsValue_changeValue;
        HideOrShow(false);
 
    }

    private void MusicEffectsValue_changeValue(float arg0)
    {
        GameDataManager.Instance.ChangeSoundEffectsValue(arg0);
    }

    private void MusicValue_changeValue(float arg0)
    {
        GameDataManager.Instance.ChangeBGMValue(arg0);
    }

    private void MusicEffectsToggle_changeValue(bool arg0)
    {
        GameDataManager.Instance.OpenOrCloseSoundEffects(arg0);
    }

    private void MusicToggle_changeValue(bool arg0)
    {
        GameDataManager.Instance.OpenOrCloseMusic(arg0);
    }

    public override void HideOrShow(bool status)
    {
        base.HideOrShow(status);
        if (status==true)
        {
            UpdatePanelInfo();
        }
    }

    private void UpdatePanelInfo()
    {
        SettingData settingData = GameDataManager.Instance.GetSettingData();
        musicToggle.isSel=settingData.isBGMOpen;
        musicEffectsToggle.isSel = settingData.isSMusicEffectsOpen;
        musicValue.nowValue = settingData.musicValue;
        musicEffectsValue.nowValue = settingData.MusicEffectsValue;
    }

    private void QuitButton_clickEvent()
    {
        HideOrShow(false);
        if (!isGameScene)
        {
            StartPanelControl.Instance.HideOrShow(true);
        }
        else
        {
            GameUIPanel.Instance.HideOrShow(true);
            Time.timeScale = 1;
        }

     
    }
}
