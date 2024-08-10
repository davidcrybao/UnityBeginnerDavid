using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum E_component
{ 
    Shooter,
    Base,
}
public class TankShooterRotate : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private E_component e_Component;
    [SerializeField] private int speed = 20;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        switch (e_Component)
        {
            case E_component.Shooter:
                transform.Rotate(Vector3.right * speed * Time.deltaTime);
                if (transform.eulerAngles.x >= 100)
                {
                    speed = -speed;
                }
                else if (transform.eulerAngles.x <= 50)
                {
                    speed = -speed;
                }
                break;
            case E_component.Base:
                transform.Rotate(Vector3.down * speed * Time.deltaTime);
                if (transform.eulerAngles.y >= 350)
                {
                    speed = -speed;
                }
                else if (transform.eulerAngles.y <= 10)
                {
                    speed = -speed;
                }
                break;
        }
       
    }
}
