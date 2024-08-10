using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed=1;
    private bool isMoving = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("test");
            isMoving = !isMoving;
        }
        if (isMoving)
        {
            Move();
        }

    }
    private void Move()
    {
       transform.Translate(Vector3.forward* speed*Time.deltaTime);
    }
}
