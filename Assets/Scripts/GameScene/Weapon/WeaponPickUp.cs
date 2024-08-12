using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerTank>().SetWeapon(weapons[Random.Range(0,3)]);

            Destroy(this.gameObject);
        }
    }
}
