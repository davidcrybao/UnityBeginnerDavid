using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Text2
{
    [SerializeField]
    private int text;
}
public class Test : MonoBehaviour
{
    [HideInInspector]
    public int i = 5;
    //不会显示出来
    public Dictionary<int, string> dic;
    [SerializeField]
    private Text2 text2;
    private void Awake()
    {
        print("Awaka");
    }

    void Start()
    {
        print("start");   
    }

    private void FixedUpdate()
    {
        print("FixedUpdate");
    }
    void Update()
    {
        print("Update");
    }
    private void LateUpdate()
    {
        print("LateUpdate");
    }
    private void OnEnable()
    {
        print("OnEnable");
    }
    private void OnDisable()
    {
        print("OnDisabler");
    }
    private void OnDestroy()
    {
        print("OnDestroy");
    }
}
