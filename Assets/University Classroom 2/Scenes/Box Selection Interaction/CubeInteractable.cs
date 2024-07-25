//using CsvHelper;
using System.Text; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using System.IO;
using TMPro; 
using System.Globalization;
using UnityEngine.XR.Interaction.Toolkit;
using static System.Console;
// using Microsoft.VisualBasic.FileIO;
// using UnityEngine.Rendering;
// using static UnityEngine.UIElements.UxmlAttributeDescription;

public class CubeInteractable : MonoBehaviour 
{
    //string _filePath = "C://Users//lydial1//Documents//Curiosity Ratings//ratings.csv"; // file path to the csv file. 
    //private string _filePath = "C:\\Users\\lydial1\\Documents\\CuriosityEEG Participant Ratings"; 
    private string _filePath = "";
    private string _fileName = ""; 
    //private string _fileName = "curiosity ratings"; 
    /*private string _filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private string _fileName = "curiosity_ratings.csv";*/
    /*private string _filePath;
    private string _fileName = "curiosity_ratings.csv"; */

    public int _currQuestion = 1;

    public TMP_Text questionNum;
    public TMP_Text curiosityRating;
    public TMP_Text satisfactionRating; 

    ArrayList _questionNumber = new ArrayList(); // create a list for the question numbers. This collects the number of questions we go through  
    ArrayList _curiosityRating = new ArrayList(); // create a list for the participant's curiosity rating. 
    ArrayList _satRating = new ArrayList(); // create a list for the participan't satisfaction rating. 
    //do a list to specify the type. then push back vals not add. 

    bool _satisfaction = false; // set the satisfaction rating to false.
    
    
    // Start is called before the first frame update
    void Start()
    {
        //_filePath = Path.Combine(UnityEngine.Application.persistentDataPath, _fileName); 
        _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CuriosityEEG Participant Ratings");
        Directory.CreateDirectory(_filePath); // Ensure the directory exists

        // Generate a unique filename with timestamp
        _fileName = $"ratings_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv";
    }


    // Update is called once per frame
    void Update() {
        questionNum.text = _currQuestion.ToString() + ", ";

        curiosityRating.text = CuriositynRatingPrint();
        
        satisfactionRating.text = SatisfactionRatingPrint();
        
        if (_currQuestion == 10) { // when the participant goes through 60 questions, write all the stuff that we compiled into the lists to the excel file. 
            WriteCSV();
        }
       
        // append data based on Ontrigger enter collision, then store data. fixed update
        
    }
    public String CuriositynRatingPrint()
    {
        string returnVal = "";
        for (int i = 0; i < _curiosityRating.Count; i++)
        {
            returnVal +=_curiosityRating[i].ToString() + ", ";
        }
        return returnVal;
    }

    public String SatisfactionRatingPrint()
    {
        string returnVal = "";
        for (int i = 0; i < _satRating.Count; i++)
        {
            returnVal += _satRating[i].ToString() + ","; 
        }
        return returnVal; 
    }
    

    public void rating(int ratingVal)  // I can change the value of this rating in Unity. 
    {
        if (_satisfaction == false)
        {
            // if satisfaction is false (it starts as false!) then we'll register the participant's selection as a 'curiosity rating', and add it to the excel file.
            _curiosityRating.Add(ratingVal); // add the participant's rating to the '_curiosityRating' column in the excel file. 
            _satisfaction = true; // set satisfaction to be true, so we enter the other loop. 
        }
        else
        {
            // if satisfaction is false, then we'll register the participant's selection as a 'satisfaction rating', and add it to the excel file. 
            _satRating.Add(ratingVal); // add the participant's rating to the '_satRating' column in the excel file. 
            _satisfaction = false; // set satisfaction to be false, so we enter the other loop. 
            _questionNumber.Add(_currQuestion); // add the current question number to the 'currQuestion' column in the excel file. 
            _currQuestion += 1; // increment 'currQuestion'.
        }
    }



    void WriteCSV()
    {
        string filePath = Path.Combine(_filePath, _fileName);

        var csvData = new StringBuilder();
        csvData.AppendLine("questionNum, curiosityRating, satifactionRating"); // write the labels of each column into the excel file.

        for (int i = 0; i < _satRating.Count; i++) {
            // csvData.AppendLine(_questionNumber[i].ToString() + "," + _curiosityRating[i].ToString() + "," + _satRating[i].ToString()); // write the data of the i-th element in each list into a row of the excel file.
            csvData.AppendLine($"{_questionNumber[i]}, {_curiosityRating[i]}, {_satRating[i]}");
           
            print($"CSV file created: {csvData[i].ToString()}");
        }
        File.WriteAllText(filePath, csvData.ToString());
        
        
        _fileName = $"ratings_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.csv";

    }
}
