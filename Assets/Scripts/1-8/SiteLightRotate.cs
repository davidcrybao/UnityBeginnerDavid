using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteLightRotate : MonoBehaviour
{
    [SerializeField] private int rotateSpeed = 20;
    [SerializeField] private Transform rotateBase;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateBase!=null)
        {
            transform.RotateAround(rotateBase.position, Vector3.up , rotateSpeed * Time.deltaTime);
        }
    }
}
