using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PickupType
{ 
    health,
    attack,
    defence,
    speed,

}
public class OtherPickups : MonoBehaviour
{
    [SerializeField] private PickupType pickupType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTank player = other.GetComponent<PlayerTank>();
            switch (pickupType)
            {
                case PickupType.health:
                    player.UpdateHealth(5);
                    break;
                case PickupType.attack:
                    player.UpdateAttack(1);
                    break;
                case PickupType.defence:
                    player.UpdateDefence(1);
                    break;
                case PickupType.speed:
                    player.UpdateSpeed(2);
                    break;
            }

        }
    }
}
