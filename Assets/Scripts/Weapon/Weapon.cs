using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private Transform[] firePosition;

    public void Fire(TankBase shooterObj)
    {
        for (int i = 0; i < firePosition.Length; i++)
        {
            GameObject obj = Instantiate(bulletPrefab.gameObject, transform.position, transform.rotation);
            Bullet bullet = obj.GetComponent<Bullet>();
            bullet.SetFather(shooterObj);
        }
    }
}