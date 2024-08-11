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

    
    public void ChangeValue(float value)
    {

        audioSource.volume = Mathf.Clamp01(value);
    }
    /// <summary>
    /// true=æ≤“Ù  false=ø™∆Ù“Ù¿÷
    /// </summary>
    /// <param name="status"></param>
    public void OpenMusic(bool status)
    {
        audioSource.mute = !status;
    }
}
