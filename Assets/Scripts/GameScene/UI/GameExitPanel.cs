using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExitPanel : BasePanel<GameExitPanel>
{
    [SerializeField] private CustomGUIButton quitButton;
    [SerializeField] private CustomGUIButton confimQuitButton;
    [SerializeField] private CustomGUIButton continueButton;

    private void Start()
    {
        confimQuitButton.clickEvent += ExitButton_clickEvent;
        continueButton.clickEvent += ContinueButton_clickEvent;
        quitButton.clickEvent += ContinueButton_clickEvent;
        HideOrShow(false);
    }

    private void ContinueButton_clickEvent()
    {
        HideOrShow(false);
        GameUIPanel.Instance.HideOrShow(true);
        Time.timeScale = 1;
    }

    private void ExitButton_clickEvent()
    {
        HideOrShow(false);
        SceneManager.LoadScene(0);
    }
}