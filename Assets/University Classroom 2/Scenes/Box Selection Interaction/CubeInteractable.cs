//using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
// using UnityEngine.Rendering;
// using static UnityEngine.UIElements.UxmlAttributeDescription;

public class CubeInteractable : MonoBehaviour
{
    string filePath = "ratings.csv"; // file path to the csv file. 
    public int questionNum { get; set; } = 1; // the question number will start at 1. 

    public List<CuriosityRating> ratingList = new List<CuriosityRating>(); // create a list to hold the rating. 


    [System.Serializable]
    public class CuriosityRating
    {
        public int questionNumber { get; set; }
        public int rating { get; set; }
    }


    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.dataPath + "/ratings.csv";
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var question = new CuriosityRating()
            {
                questionNumber = questionNum,
                rating = 1
            };
            ratingList.Add(question);
            questionNum += 1;
            WriteCSV();
        }
       



        /*if (questionNum == 10)
        {
            using var writer = new StreamWriter("C://Users//smeronek//Documents//TriviaParadigm//triviaQuestions.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);


            csv.WriteHeader<Questions>();
            csv.NextRecord();
            foreach (var record in records)
            {
                csv.WriteRecord(record);
                csv.NextRecord();
            }
        }*/
    }

    public void WriteCSV()
    {



        /*using (var writer = new StreamWriter("Documents", false))
        {
            writer.WriteLine("Question number, Rating");
            for (int i = 0; i < ratingList.Count; i++)
            {
                writer.WriteLine((i + 1).ToString() + "," + ratingList[i].rating.ToString());
            }*/
        /*using var writer = new StreamWriter("C://Users//lydial1//curiosity - eeg - classroom//RatingResultsCSV", false);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.WriteHeader<CuriosityRating>();
        csv.NextRecord();

        foreach (var record in ratingList)
        {
            csv.WriteRecord(record);
            csv.NextRecord();
        }*/

        /*if (myParticipantList.participant.Length > 0) {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Rating"); // headings of excel spreadsheet.
            tw.Close();

            tw = new StreamWriter(filename, true); // true, because we're appending new data

            for (int i = 0; i < myParticipantList.participant.Length; i++) {
                tw.WriteLine(myParticipantList.participant[i].rating);
            }

            tw.Close();
        }*/
        //}
    }
}
