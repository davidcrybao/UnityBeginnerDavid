using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;
    public static AudioController Instance =>instance;

    private AudioSource audioSource;
    private void Awake()
    {
        audioSource=gameObject.GetComponent<AudioSource>();
            instance = this;
    }
    /// <summary>
    /// 在start启用这个,awake有些组件可能没初始化完毕
    /// </summary>
    private void Start()
    {
        ChangeValue(GameDataManager.Instance.GetSettingData().musicValue);
        OpenMusic(GameDataManager.Instance.GetSettingData().isBGMOpen);
    }

    public void ChangeValue(float value)
    {

        audioSource.volume = Mathf.Clamp01(value);
    }
    /// <summary>
    /// true=静音  false=开启音乐
    /// </summary>
    /// <param name="status"></param>
    public void OpenMusic(bool status)
    {
        audioSource.mute = !status;
    }
}
