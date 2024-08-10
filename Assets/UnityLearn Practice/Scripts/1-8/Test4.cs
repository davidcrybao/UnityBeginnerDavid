using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test4 : MonoBehaviour
{
    [SerializeField] private GameObject tank;

    [Space(1)]
    [Header("GameObject2µƒ…Ë÷√")]
    [SerializeField] private int destroyDelay;

    [SerializeField] private bool activeStatus;
    [SerializeField] private string name2;
    private GameObject tankobj;

    // Start is called before the first frame update
    private void Start()
    {
        tankobj = Instantiate(tank, this.transform);
        TankBScript tankBScript;
        tankobj.TryGetComponent<TankBScript>(out tankBScript);
        tankBScript.enabled = false;
        ChangeName();
    }

    private void ChangeName()
    {
        tank.name = name2;
    }

    [ContextMenu("ChangeStatus")]
    private void ChangeStatus()
    {
        tank.SetActive(activeStatus);
    }

    [ContextMenu("DestroyInSeconds")]
    private void DestroyInSeconds()
    {
        Destroy(tank, destroyDelay);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}