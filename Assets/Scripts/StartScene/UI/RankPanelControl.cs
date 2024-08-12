using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanelControl : BasePanel<RankPanelControl>
{
    [SerializeField] private CustomGUILabel content;
    [SerializeField] private CustomGUIButton quitButton;
    private string space = "                 ";

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

        if (status == true)
        {
            UpdateScores();
        }
    }

    /// <summary>
    /// �����Ӿ��ϸ���,Ȼ������Ҳ��Ҫ�����ϸ���
    /// </summary>
    public void UpdateScores()
    {
        List<PlayerData> playerRankDatas = GameDataManager.Instance.GetPlayerData();

        content.content.text = "";
        for (int i = 0; i < playerRankDatas.Count; i++)
        {

            content.content.text += string.Format("��{3}��"+space+"������{0}"+space+"�ɼ���{1}"+space+ "������{2} \n",
                playerRankDatas[i].name, playerRankDatas[i].time, playerRankDatas[i].score,i+1);
        }
    }
}