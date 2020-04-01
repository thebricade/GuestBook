using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCamera : MonoBehaviour
{
    public GameObject cameraTable, shelfCamera; 
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTable = GameObject.Find("TableCamera");
        shelfCamera = GameObject.Find("ShelfCamera");
        
        cameraTable.GetComponent<Camera>().enabled = true;
        shelfCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
