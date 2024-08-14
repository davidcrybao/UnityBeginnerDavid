using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyTank : BaseTank
{
    [SerializeField] private float shootInterval=2;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform[] waypoints;
    [SerializeField]private Transform target;
    private float timeCounter;
    private int currentWaypointIndex = 1;
    private float uiShowTime;
    public override void Fire()
    {
        if (target==null)
        {
            return;
        }
       
      
        if (Vector3.Distance(transform.position,target.position)<10)
        {
            Debug.Log("123"); weapon.Fire(this);
        }
    }

   
    void Update()
    {
        Move();

        timeCounter += Time.deltaTime;
        if (timeCounter > shootInterval)
        {
            timeCounter = 0;
            Fire();
        }
        if (target!=null)
        {
            transform.LookAt(target);
        }
    }
    private void Move()
    {

        // ���û��·���㣬ֱ�ӷ���
        if (waypoints.Length == 0) return;

        // ��ȡ��ǰ·����
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // ���㳯��Ŀ���ķ���
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        // ����ÿ֡�ƶ���λ��
        Vector3 move = direction * moveSpeed * Time.deltaTime;

        // �ƶ�����
        transform.position += move;

        // ����Ƿ񵽴�Ŀ��㣨����ʹ�þ���Ƚϣ�
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.2f)
        {
            // �л�����һ��·����
            currentWaypointIndex++;

            // ����������һ��·���㣬����ѭ����ͷ��ʼ����ֹͣ
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;  // ѭ��·��
                // ����ֹͣ�ƶ�
                // enabled = false; 
            }
        }
    }

    private void OnGUI()
    {
        if (uiShowTime>0)
        {
            uiShowTime -= Time.deltaTime;



            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            screenPos.y = Screen.height - screenPos.y;
            GUI.Button(new Rect(screenPos.x, screenPos.y, 50, 50), "Test");
        }

    }
    public override void OnDamaged(BaseTank other)
    {
        base.OnDamaged(other);
        uiShowTime = 3f;
    }
}
