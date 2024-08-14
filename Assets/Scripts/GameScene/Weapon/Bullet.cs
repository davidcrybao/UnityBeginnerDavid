using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletSpeed = 5;
    [SerializeField] private GameObject hitEffect;
    public BaseTank fatherObj;

    private AudioSource audio;
    private void Awake()
    {
        audio= GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Translate(bulletSpeed * Vector3.forward * Time.deltaTime);
    }

    public void SetFather(BaseTank tank)
    {
        fatherObj = tank;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            GameObject eff = Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            audio.mute = !GameDataManager.Instance.GetSettingData().isSMusicEffectsOpen;
            audio.volume= GameDataManager.Instance.GetSettingData().MusicEffectsValue;
            audio.Play();
            Destroy(this.gameObject,2);
            Destroy(eff, 2);
        }

        BaseTank tank;
        if (other.TryGetComponent<BaseTank>(out tank))
        {
            if (tank == fatherObj|| fatherObj.CompareTag(tank.tag)) return;
            tank.OnDamaged(fatherObj);
            GameObject eff = Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            audio.mute = !GameDataManager.Instance.GetSettingData().isSMusicEffectsOpen;
            audio.volume = GameDataManager.Instance.GetSettingData().MusicEffectsValue;
            audio.Play();
            Destroy(this.gameObject, 2);
            Destroy(eff, 2);
        }
      
    }
}
