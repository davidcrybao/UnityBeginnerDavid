using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanelControl : BasePanel<StartPanelControl>
{
    [SerializeField] private CustomGUIButton startButton;

    [SerializeField] private CustomGUIButton settingButton;
    [SerializeField] private CustomGUIButton quitButton;
    [SerializeField] private CustomGUIButton rankButton;

    void Start()
    {
        startButton.clickEvent += StartButton1_clickEvent;
        settingButton.clickEvent += SettingButton_clickEvent;
        quitButton.clickEvent += QuitButton_clickEvent;
        rankButton.clickEvent += RankButton_clickEvent;
    }

    private void RankButton_clickEvent()
    {
        RankPanelControl.Instance.HideOrShow(true);
        HideOrShow(false);
    }

    private void QuitButton_clickEvent()
    {
        Application.Quit();
    }

    private void SettingButton_clickEvent()
    {
        SettingPanel.Instance.HideOrShow(true);
        HideOrShow(false);
    }

    private void StartButton1_clickEvent()
    {
        SceneManager.LoadScene(1);
    }
}
