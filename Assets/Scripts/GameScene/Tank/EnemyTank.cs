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

        // 如果没有路径点，直接返回
        if (waypoints.Length == 0) return;

        // 获取当前路径点
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // 计算朝向目标点的方向
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        // 计算每帧移动的位置
        Vector3 move = direction * moveSpeed * Time.deltaTime;

        // 移动物体
        transform.position += move;

        // 检查是否到达目标点（可以使用距离比较）
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.2f)
        {
            // 切换到下一个路径点
            currentWaypointIndex++;

            // 如果到达最后一个路径点，可以循环从头开始，或停止
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;  // 循环路径
                // 或者停止移动
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
