using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RTest4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.SetCursor();
        int n1 = Random.Range(1, 5);
        float f1 = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
       // SceneManager.LoadScene("Test2");
    }
}
