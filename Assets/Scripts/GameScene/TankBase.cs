using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBase : MonoBehaviour
{
    [SerializeField] protected int attack;
    [SerializeField] protected int defence;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int moveSpeed;
    [SerializeField] protected int bodyRotateSpeed;
    [SerializeField] protected int headRotateSpeed;

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

    public virtual void OnDamaged(TankBase other)
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
