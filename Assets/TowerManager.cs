using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubePrefabs;
    [SerializeField] private int towerHeight ;
    void Start()
    {
        Create();
    }

    // Update is called once per frame 
    void Update()
    {
        
    }
    private void Create()
    {
        for (int i = 0; i < towerHeight; i++)
        {
            cubePrefabs.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
           
        }

        for (int i = towerHeight-1; i >=0; i--)
        {
            cubePrefabs[i].transform.localPosition=Vector3.up*(towerHeight-i);
            cubePrefabs[i].transform.localScale = new Vector3(1, 0, 1) * i + Vector3.one;
            cubePrefabs[i].transform.SetParent(this.transform);
        }
    }
}
