using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using TMPro;

public class HouseCamera : MonoBehaviour
{
    public GameObject houseCamera;

    public GameObject moveButton;
    public GameObject DaysView;

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

    private Vector3 cameraStartingPosition;
    private Quaternion cameraStartingRotation; 
    
    // Start is called before the first frame update
    void Start()
    {
        currentlyLookingAt = LookingAt.Dresser; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera()
    {
        switch (currentlyLookingAt)
        {
            case LookingAt.Dresser:
               // currentlyLookingAt = LookingAt.TV;
                StartCoroutine(RotateCamera());
               currentlyLookingAt = LookingAt.TV; 
                break;
            case LookingAt.TV:
                DaysView.SetActive(false);
                Debug.Log("Looking At TV");
                Fungus.Flowchart.BroadcastFungusMessage("TVOFF");
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

    public void HideButtons()
    {
        moveButton.SetActive(false);
        houseCamera.GetComponent<Camera>().enabled = false;
    }

    public void EnableCamera()
    {
        houseCamera.GetComponent<Camera>().enabled = true; 
    }

    public void ShowButtons()
    {
        moveButton.SetActive(true);
        moveButton.GetComponentInChildren<TextMeshProUGUI>().text = "Turn Off TV";
        currentlyLookingAt = LookingAt.TV;
    }
    
}
