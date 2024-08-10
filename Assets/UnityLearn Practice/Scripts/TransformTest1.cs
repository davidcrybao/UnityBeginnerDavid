using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Reverse3();
        List<Transform> newList = transform.FindAllByName(" HAHA");
        if (newList.Count>0)
        {
            print("ур╣╫ак");
            foreach (Transform item in newList)
            {
                print(item.name);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
