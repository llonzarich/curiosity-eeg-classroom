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

public class CubeInteractable : MonoBehaviour {
    private string _filePath = "";
    private string _fileName = ""; 

    public int _currQuestion = 1;

    public TMP_Text questionNum; // variable for the text of the question number on the UI panel. 
    public TMP_Text curiosityRating; // variable for the text of the curiosity rating on the UI panel.
    public TMP_Text satisfactionRating; // variable for the text of the satisfaction rating on the UI panel.

    ArrayList _questionNumber = new ArrayList(); // create a list for the question numbers. This collects the number of questions we go through.  
    ArrayList _curiosityRating = new ArrayList(); // create a list for the participant's curiosity rating. 
    ArrayList _satRating = new ArrayList(); // create a list for the participant satisfaction rating. 

    bool _satisfaction = false; // set the satisfaction rating to false.
    
    [SerializeField]
    public GameObject questionAnswer;

    private bool isQuitting = false;

    public int currCuriosity = 1; // variable for the current value from the cubes. Default value = 1.
    public int currSatisfaction = 1; // variable for the current value from the cubes. Default value = 1. 

    /*[SerializeField]
    public GameObject cube1;*/
    
    
    // Start is called before the first frame update
    void Start() {
        _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CuriosityEEG Participant Ratings");
        
        Directory.CreateDirectory(_filePath); // Ensure the directory exists

        _fileName = $"ratings_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv"; // generate a unique file name. 
    }


    // Update is called once per frame
    void Update()
    {
        questionNum.text = "Question Number: " + _currQuestion.ToString() + ", "; // print the question number on the UI panel. 

        curiosityRating.text = "Curiosity Rating: " + CuriositynRatingPrint(); // print the participant-selected curiosity rating on the UI panel.

        satisfactionRating.text = "Satisfaction Rating: " + SatisfactionRatingPrint(); // print the participant-selected satisfaction rating on the UI panel.

        if (_currQuestion == 20 && !isQuitting) { // when the participant goes through 60 questions, write all the stuff that we compiled into the lists to the excel file. 
            isQuitting = true;
            WriteCSV();
            StartCoroutine(QuitAfterDelay());
        }
    }


    /*public void CheckPrint(Collider other) {
        if (other.gameObject.Active == false) {
            
        }
    }*/

    
    // function will allow us to exit the program once the participant runs through all 60 questions.
    IEnumerator QuitAfterDelay() {
            float delay = 3f;
            float timer = 0;

            while (timer < delay) {
                timer += Time.deltaTime;
                questionAnswer.GetComponent<TMPro.TextMeshProUGUI>().text = "Closing in " + (delay - timer).ToString("F1") + " seconds";
                yield return null;
            }
            
            UnityEditor.EditorApplication.isPlaying = false;
    }
    
    
    public String CuriositynRatingPrint()
    {
        // Should just show the current value and then lock when the next stage set.
        // Then go back to being 1 at the start of the next curiosity stage
        string returnVal = "";
        for (int i = 0; i < _curiosityRating.Count; i++) {
            returnVal +=_curiosityRating[i].ToString() + ", ";
        }
        return returnVal;
    }

    
    public String SatisfactionRatingPrint() {
        // Should just show the current value and then lock when the next stage set.
        // Then go back to being 1 at the start of the next curiosity stage
        string returnVal = "";
        for (int i = 0; i < _satRating.Count; i++) {
            returnVal += _satRating[i].ToString() + ","; 
        }
        return returnVal; 
    }
    

    public void rating(int ratingVal)  // I can change the value of this rating variable in Unity. 
    {
        if (_satisfaction == false) {
            // should only add to curiosityRating at the end of the curiosity phase
            // rating value should only change the currentRating text
            
            // if satisfaction is false (it starts as false!) then we'll register the participant's selection as a 'curiosity rating', and add it to the excel file.
            _curiosityRating.Add(ratingVal); // add the participant's rating to the '_curiosityRating' column in the excel file. 
            _satisfaction = true; // set satisfaction to be true, so we enter the other loop. 
        }
        else {
            // if satisfaction is false, then we'll register the participant's selection as a 'satisfaction rating', and add it to the excel file. 
            _satRating.Add(ratingVal); // add the participant's rating to the '_satRating' column in the excel file. 
            _satisfaction = false; // set satisfaction to be false, so we enter the other loop. 
            _questionNumber.Add(_currQuestion); // add the current question number to the 'currQuestion' column in the excel file. 
            _currQuestion += 1; // increment 'currQuestion'.
        }
    }


    // write everything, one-by-one, from each of the 3 lists, to the Excel spreadsheet.
    void WriteCSV() {
        string filePath = Path.Combine(_filePath, _fileName);

        var csvData = new StringBuilder();
        csvData.AppendLine(
            "questionNum, curiosityRating, satifactionRating"); // write the labels of each column into the excel file.

        for (int i = 0; i < _satRating.Count; i++) {
            csvData.AppendLine($"{_questionNumber[i]}, {_curiosityRating[i]}, {_satRating[i]}");

            print($"CSV file created: {csvData[i].ToString()}");
        }

        File.WriteAllText(filePath, csvData.ToString());
        
        _fileName = $"ratings_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.csv";
    }
}
