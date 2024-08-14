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
    [SerializeField] private int rewardValue=1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTank player = other.GetComponent<PlayerTank>();
            switch (pickupType)
            {
                case PickupType.health:
                    player.UpdateHealth(rewardValue);
                    break;
                case PickupType.attack:
                    player.UpdateAttack(rewardValue);
                    break;
                case PickupType.defence:
                    player.UpdateDefence(rewardValue);
                    break;
                case PickupType.speed:
                    player.UpdateSpeed(rewardValue);
                    break;
            }

        }
    }
}
