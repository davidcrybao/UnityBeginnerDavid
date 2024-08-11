using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanelControl : BasePanel<RankPanelControl>
{
    [SerializeField] private CustomGUILabel content;
    [SerializeField] private CustomGUIButton quitButton;

    private void OnEnable()
    {
        quitButton.clickEvent += QuitButton_clickEvent;
    }
    private void OnDisable()
    {
        quitButton.clickEvent -= QuitButton_clickEvent;
    }
    private void Start()
    {
        HideOrShow(false);
       
    }

    private void QuitButton_clickEvent()
    {
        StartPanelControl.Instance.HideOrShow(true); 
        HideOrShow(false);
    }

    public override void HideOrShow(bool status)
    {
        base.HideOrShow(status);

        if (status==true)
        {
            UpdateScores();
        }

    }
    public void UpdateScores()
    {
    
    }
}
