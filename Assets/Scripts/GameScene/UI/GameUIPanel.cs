using UnityEngine;

public class GameUIPanel : BasePanel<GameUIPanel>
{
    [SerializeField] private CustomGUITexture healthBar;
    [SerializeField] private CustomGUIButton settingButton;
    [SerializeField] private CustomGUIButton quitButton;

    [SerializeField] private CustomGUILabel scoreText;
    [SerializeField] private CustomGUILabel timeText;

    [HideInInspector]
    public float nowTime = 0;

    private int time;

    [HideInInspector]
    public int nowScore = 0;

    private void Start()
    {
        quitButton.clickEvent += QuitButton_clickEvent;
        settingButton.clickEvent += SettingButton_clickEvent;
    }

    private void Update()
    {
        nowTime += Time.deltaTime;
        time = (int)nowTime;
        timeText.content.text = "";

        if (time / 3600 > 0)
        {
            timeText.content.text += time / 3600 + " ±";
        }

        if (time % 3600 / 60 > 0 || timeText.content.text != "")
        {
            timeText.content.text += time % 3600 / 60 + "∑÷";
        }
        timeText.content.text += time % 60 + "√Î";
    }

    public void AddScore(int score)
    {
        nowScore += score;
        scoreText.content.text = nowScore.ToString();
    }

    public void UpdateHP(int maxHP, int HP)
    {
        healthBar.guiPos.width = (float)HP / maxHP * 200;
    }

    private void SettingButton_clickEvent()
    {
        SettingPanel.Instance.HideOrShow(true);
        HideOrShow(false);
        Time.timeScale = 0;
    }

    private void QuitButton_clickEvent()
    {
   
        GameExitPanel.Instance.HideOrShow(true);
        HideOrShow(false);
        Time.timeScale = 0;
    }
}