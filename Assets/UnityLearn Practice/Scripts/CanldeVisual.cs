using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanldeVisual : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private Transform dayNightLight;
    private float number;
    private float dayNightNumber;
    void Start()
    {
        dayNightNumber = 1f ;
        number= 0.5f ;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (light.intensity>2)
        {
            number = -number;
        }
        else if (light.intensity<0.5)
        {
            number = -number;
        }

        if (dayNightLight.rotation.x>=360)
        {
            dayNightNumber = -dayNightNumber;
        }
        else if (dayNightLight.rotation.x <= 0)
        {
            dayNightNumber = -dayNightNumber;
        }

        light.intensity += number * Time.deltaTime;        // 添加 Time.deltaTime 使其每帧更新
        dayNightLight.Rotate(Vector3.right, Time.deltaTime * dayNightNumber);
    }
}
