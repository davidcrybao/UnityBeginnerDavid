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
    /// 这是视觉上更新,然后我们也需要数据上更新
    /// </summary>
    public void UpdateScores()
    {
        List<PlayerData> playerRankDatas = GameDataManager.Instance.GetPlayerData();

        content.content.text = "";
        for (int i = 0; i < playerRankDatas.Count; i++)
        {

            content.content.text += string.Format("第{3}名"+space+"姓名是{0}"+space+"成绩是{1}"+space+ "分数是{2} \n",
                playerRankDatas[i].name, playerRankDatas[i].time, playerRankDatas[i].score,i+1);
        }
    }
}