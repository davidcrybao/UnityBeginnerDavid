using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneRotate : MonoBehaviour
{
    [SerializeField] private Transform[] transforms;
    [SerializeField]private int rotateSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        if (transforms.Length==0||transforms==null)
        {
            return;
        }

        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].eulerAngles += Vector3.up * rotateSpeed * Time.deltaTime;
        }
    }
}
