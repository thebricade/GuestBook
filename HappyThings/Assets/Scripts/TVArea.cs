using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; 

public class TVArea : MonoBehaviour
{
    public Camera camera;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "TVHotspot")
                {
                    Fungus.Flowchart.BroadcastFungusMessage("TVON");
                }
            }
        }
    }
}
