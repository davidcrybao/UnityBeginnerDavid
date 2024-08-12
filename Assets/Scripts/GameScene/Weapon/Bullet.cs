using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletSpeed = 5;
    [SerializeField] private GameObject hitEffect;
    public TankBase fatherObj;


    void Update()
    {
        transform.Translate(bulletSpeed * Vector3.forward * Time.deltaTime);
    }

    public void SetFather(TankBase tank)
    {
        fatherObj = tank;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            GameObject eff = Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            AudioSource audioSource= GetComponent<AudioSource>();
            audioSource.mute = GameDataManager.Instance.GetSettingData().isSMusicEffectsOpen;
            audioSource.volume= GameDataManager.Instance.GetSettingData().MusicEffectsValue;
        }
        Destroy(this.gameObject);
    }
}
