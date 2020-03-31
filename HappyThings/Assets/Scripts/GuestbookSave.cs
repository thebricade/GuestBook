using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GuestbookSave : MonoBehaviour
{
    public class Page
    {
        public int pageNumber;
        public string pageContent;

        public Page()
        {
            
        }

        public Page(int page, string content)
        {
            this.pageNumber = page;
            this.pageContent = content; 
        }
    }
    
    
    
    
    public TextMeshProUGUI guestbookText;
    private Page currentPage;
   // private int pagesLoaded;
    private string[] pagesLoaded; 
    
    private List<StreamReader> allSavedFiles;

    private void Awake()
    { 
        //should probably run something to double check if there is a blank page but lets add that later
        currentPage = new Page();
        CheckAmountOfPages();
        
        currentPage.pageNumber = pagesLoaded.Length +1; 
        Debug.Log("current page number is "+currentPage.pageNumber);

    }


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


    public void CheckAmountOfPages()
    {
        pagesLoaded = Directory.GetFiles(Application.dataPath + "/", "*.txt");
        Debug.Log(pagesLoaded.Length);
    }
    
    //function for reading text from the SaveGuest.txt 
    public void ReadTextFile(string filePath, string fileName)
    {
         var fileLoad = new StreamReader(Application.dataPath + filePath + "/" + fileName);
         var fileText = fileLoad.ReadToEnd(); 
         
         //update guestbook text
         guestbookText.text = fileText; 
         
         Debug.Log(fileLoad.ReadToEnd());
         fileLoad.Close();
    }
    
    //this is just attaching it to the button (I know this is dirty buuuut i'm mainly trying to figure out saving) '
    public void SignBook()
    {
        var currentText = guestbookText.text;
        SaveTextFile("SaveGuest.txt", currentText);   
    }
    
    //function for saving text to SaveGuest.txt 
    public void SaveTextFile(string fileName, string data)
    {
        using (var outputFile = new StreamWriter(Path.Combine(Application.dataPath, fileName)))
        {
            outputFile.Write(data);
        }
    }
    
    
}
