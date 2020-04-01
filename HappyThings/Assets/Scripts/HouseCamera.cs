using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCamera : MonoBehaviour
{
    public GameObject houseCamera;

    enum LookingAt
    {
        Dresser,
        TV,
        Table,
        Kitchen,
        Outside
    }
    
    LookingAt currentlyLookingAt;
    private bool rotating = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        currentlyLookingAt = LookingAt.Dresser; 
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentlyLookingAt)
        {
            case LookingAt.Dresser:
                break;
            case LookingAt.TV:
                //houseCamera.transform.Rotate(Vector3.down, 500.0f * Time.deltaTime);
                break;
            case LookingAt.Table:
                break;
            case LookingAt.Kitchen:
                break;
            case LookingAt.Outside:
                break;
            default:
                Debug.LogError("Incorrect setting for camera");
                break;
        }
    }

    public void MoveCamera()
    {
        switch (currentlyLookingAt)
        {
            case LookingAt.Dresser:
               // currentlyLookingAt = LookingAt.TV;
                StartCoroutine(RotateCamera());
                break;
            case LookingAt.TV:
                break;
            case LookingAt.Table:
                break;
            case LookingAt.Kitchen:
                break;
            case LookingAt.Outside:
                break;
            default:
                Debug.LogError("Incorrect setting for camera");
                break;
        }
    }

    IEnumerator RotateCamera()
    {
        float moveSpeed = 1f;
        while(houseCamera.transform.rotation.y < 180)
        {
                                                            //start position                     //end position                         //how long
            houseCamera.transform.rotation = Quaternion.Lerp(houseCamera.transform.rotation, Quaternion.Euler(Vector3.down), moveSpeed * Time.deltaTime);
            yield return null;
        }
        houseCamera.transform.rotation = Quaternion.Euler(0, 180, 0);
        yield return null;
    }
    
}
