using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private int speed=5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }
    private void Move()
    {
  
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(0, 0, verticalInput);
        if (verticalInput!=0)
        {

            // ʹ�� TransformDirection ����ȡ��ȷ�����緽��
            Vector3 worldDirection = transform.TransformDirection(moveDirection);
            transform.position += worldDirection * Time.deltaTime*speed;

            //transform.Translate(transform.forward * verticalInput * Time.deltaTime * speed);
        }
       
    }

    private void Rotate()
    {
        float horizontraInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(0, horizontraInput, 0);
        transform.eulerAngles += moveDirection * Time.deltaTime * speed*10;

    }
}
