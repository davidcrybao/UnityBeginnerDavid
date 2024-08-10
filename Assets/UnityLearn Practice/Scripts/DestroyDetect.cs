using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDetect : MonoBehaviour
{
    private int count = 0;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(20, Vector3.forward,20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DestroyDetect>()!=null)
        {
            count++;

            if (count==3)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Plane"))
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
