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
    /// ��start�������,awake��Щ�������û��ʼ�����
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
    /// true=����  false=��������
    /// </summary>
    /// <param name="status"></param>
    public void OpenMusic(bool status)
    {
        audioSource.mute = !status;
    }
}
