using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTank : BaseTank
{
    [SerializeField] private float shootInterval;
    private float timeCounter;
    [SerializeField] private Weapon weapon;
    public override void Fire()
    {
        weapon.Fire(this);
    }


    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >shootInterval)
        {
            timeCounter = 0;
            Fire();
        }
    }
}
