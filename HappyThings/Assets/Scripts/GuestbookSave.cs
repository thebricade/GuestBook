using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GuestbookSave : MonoBehaviour
{
    public TextMeshProUGUI guestbookText;
    
    // Start is called before the first frame update
    void Start()
    {
       //small test to see if i can access this text UI (I really want to stop using basic unity text and more TMPro
        // guestbookText.text = "hello this works.";
        
        //read the current file
        ReadTextFile("","SaveGuest.txt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //function for reading text from the SaveGuest.txt 
    public void ReadTextFile(string filePath, string fileName)
    {
         var fileLoad = new StreamReader(Application.dataPath + filePath + "/" + fileName);
    }
    
    
}
