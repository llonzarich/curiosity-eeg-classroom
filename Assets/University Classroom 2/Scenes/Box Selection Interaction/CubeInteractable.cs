//using CsvHelper;
using System.Text; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using static System.Console;
// using Microsoft.VisualBasic.FileIO;
// using UnityEngine.Rendering;
// using static UnityEngine.UIElements.UxmlAttributeDescription;

public class CubeInteractable : MonoBehaviour
{
    string _filePath = "C://Users//lydial1//Documents//Curiosity Ratings//ratings.csv"; // file path to the csv file. 

    private int _currQuestion = 1;

    ArrayList _questionNumber = new ArrayList(); // create a list for the question numbers. This collects the number of questions we go through  
    ArrayList _curiosityRating = new ArrayList(); // create a list for the participant's curiosity rating. 
    ArrayList _satRating = new ArrayList(); // create a list for the participan't satisfaction rating. 

    bool _satisfaction = false; // set the satisfaction rating to false. 
    

    // Start is called before the first frame update
    void Start() {
    }


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (_satisfaction == false) { // if satisfaction is false (it starts as false!) then we'll register the participant's selection as a 'curiosity rating', and add it to the excel file.
                _curiosityRating.Add("1"); // add the participant's rating to the '_curiosityRating' column in the excel file. 
                _satisfaction = true; // set satisfaction to be true, so we enter the other loop. 
            }
            else { // if satisfaction is false, then we'll register the participant's selection as a 'satisfaction rating', and add it to the excel file. 
                _satRating.Add("1"); // add the participant's rating to the '_satRating' column in the excel file. 
                _satisfaction = false; // set satisfaction to be false, so we enter the other loop. 
                _questionNumber.Add(_currQuestion); // add the current question number to the 'currQuestion' column in the excel file. 

                _currQuestion += 1; // increment 'currQuestion'.
            }
        }

        
        if (_currQuestion == 10) { // when the participant goes through 60 questions, write all the stuff that we compiled into the lists to the excel file. 
            WriteCSV();
        }
       

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightIndex")
        {
            
        }
    }

    public void WriteCSV() {
        var csvData = new StringBuilder();
        csvData.AppendLine("questionNum, curiosityRating, satifactionRating"); // write the labels of each column into the excel file. 

        for (int i = 0; i < _satRating.Count; i++) { 
            csvData.AppendLine(_questionNumber[i].ToString() + "," + _curiosityRating[i].ToString() + "," + _satRating[i].ToString()); // write the data of the i-th element in each list into a row of the excel file.
        }
        
        File.WriteAllText(_filePath, csvData.ToString());
    }
}
