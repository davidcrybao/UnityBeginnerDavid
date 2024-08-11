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
    private new void Awake()
    {
     
        base.Awake(); 
        print("dedesd");
    }
    private void Start()
    {
        HideOrShow(false);
        quitButton.clickEvent += QuitButton_clickEvent;
        musicToggle.changeValue += MusicToggle_changeValue;
        musicEffectsToggle.changeValue+=MusicEffectsToggle_changeValue;
        musicValue.changeValue += MusicValue_changeValue;
        musicEffectsValue.changeValue += MusicEffectsValue_changeValue;
    }

    private void MusicEffectsValue_changeValue(float arg0)
    {
        throw new System.NotImplementedException();
    }

    private void MusicValue_changeValue(float arg0)
    {
        throw new System.NotImplementedException();
    }

    private void MusicEffectsToggle_changeValue(bool arg0)
    {
        throw new System.NotImplementedException();
    }

    private void MusicToggle_changeValue(bool arg0)
    {
        throw new System.NotImplementedException();
    }

    private void QuitButton_clickEvent()
    {
        StartPanelControl.Instance.HideOrShow(true);
        HideOrShow(false);
    }
}
