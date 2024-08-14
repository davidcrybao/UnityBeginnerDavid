using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTank : MonoBehaviour
{
    [SerializeField] protected int attack=1;
    [SerializeField] protected int defence=1;
    [SerializeField] protected int maxHealth=5;
    [SerializeField] protected int currentHealth=5;
    [SerializeField] protected int moveSpeed=2;
    [SerializeField] protected int bodyRotateSpeed=2;
    [SerializeField] protected int headRotateSpeed=2;

    [SerializeField] protected GameObject DestroyedEffectPreafab;
    public abstract void Fire();

    public virtual void OnDeath()
    {

        if (DestroyedEffectPreafab!=null)
        {
            GameObject fxObject = Instantiate(DestroyedEffectPreafab, this.transform.position, this.transform.rotation);
            AudioSource audio = fxObject.GetComponent<AudioSource>();
            audio.mute = GameDataManager.Instance.GetSettingData().isSMusicEffectsOpen;
            audio.volume = GameDataManager.Instance.GetSettingData().MusicEffectsValue;
            audio.Play();
        }

        Destroy(gameObject);
    }

    public virtual void OnDamaged(BaseTank other)
    {
        int damage = other.attack - defence;
        if (damage > 0) {
            currentHealth -= damage;

            if (currentHealth<=0)
            {
                currentHealth = 0;
                OnDeath();
            }

        }
    }
}
