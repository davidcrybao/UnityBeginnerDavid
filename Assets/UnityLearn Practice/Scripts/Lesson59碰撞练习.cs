using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson59碰撞 : MonoBehaviour
{
    [SerializeField] private Transform bulletTransform;
    Vector3 mousePosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            mousePosition= Camera.main.ScreenToWorldPoint(mousePosition);
            Transform bulletTrans= Instantiate(bulletTransform, mousePosition,Quaternion.identity, this.transform);
          //  bulletTrans.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
