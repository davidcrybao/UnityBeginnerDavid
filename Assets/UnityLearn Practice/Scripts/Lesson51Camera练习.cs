using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson51Camera¡∑œ∞ : MonoBehaviour
{
    [SerializeField] private Transform test;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        Debug.Log(Camera.main.WorldToScreenPoint(test.position));
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition=Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            gameObject.transform.parent = this.transform;

        }
    }
}
