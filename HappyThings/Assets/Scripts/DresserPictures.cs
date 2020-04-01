using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DresserPictures : MonoBehaviour
{
    public Camera camera;
    public GameObject[] familyPhotos;

    public Vector3[] photoStartingLocation; 

    private bool selectionMode;
    private int selectedPhoto; 
    
    void Start()
    {
        selectionMode = true; 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (selectionMode)
                {
                    if (hit.transform.name == "WeddingPhoto")
                    {
                        print("My object is clicked by mouse");
                        selectedPhoto = 1;
                        SelectedPhoto(1);
                    }

                    if (hit.transform.name == "CarPhoto")
                    {
                        selectedPhoto = 0;
                        SelectedPhoto(0);
                    }
                    if (hit.transform.name == "BabyPhoto")
                    {
                        selectedPhoto = 2; 
                        SelectedPhoto(2);
                    }
                    if (hit.transform.name == "SiblingPhoto")
                    {
                        selectedPhoto = 3; 
                        SelectedPhoto(3);
                    }
                    if (hit.transform.name == "XmasPhoto")
                    {
                        selectedPhoto = 4; 
                        SelectedPhoto(4);
                    }
                }
                else if(!selectionMode)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        ReturnPhoto(selectedPhoto);
                    }
                    
                }
            }
        }
    }

  
    
    private void SelectedPhoto(int photoNumber)
    {
        selectionMode = false;
        familyPhotos[photoNumber].transform.localPosition = new Vector3(-2.0f, 1.5f, -2.5f);
    }

    private void ReturnPhoto(int photoNumber)
    {
        familyPhotos[photoNumber].transform.localPosition = photoStartingLocation[photoNumber];
        selectionMode = true;
    }
}
