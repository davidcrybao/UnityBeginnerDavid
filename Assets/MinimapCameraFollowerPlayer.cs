using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraFollowerPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset=Vector3.zero;
    void LateUpdate()
    {
        if (player==null)
        {
            return;
        }
        offset.x = player.position.x;
        offset.z = player.position.z;
        offset.y = transform.position.y;
        transform.position = offset;

    }
}
