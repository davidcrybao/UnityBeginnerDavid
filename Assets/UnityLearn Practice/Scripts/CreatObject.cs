using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreatOneNewObjet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("test")]
    public void CreatObjectInLeft()
    {
        Vector3 vector3 = transform.TransformPoint(new Vector3(-1, 0, 1));
        GameObject gameObject = new GameObject("做强物体");
        gameObject.transform.position = vector3;
        
    }
    //理解错了
    public void CreatOneNewObjet()
    {
        Transform transform = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        transform.parent = this.transform;
        transform.position= transform.InverseTransformVector(new Vector3(-1, 0, 1));
    }
}
