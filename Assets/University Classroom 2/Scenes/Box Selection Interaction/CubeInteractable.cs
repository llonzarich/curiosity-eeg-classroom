using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CubeInteractable : MonoBehaviour
{
    string filename = "ratings.csv";

    [System.Serializable]
    public class Participant {
        public string rating; 
    }

    [System.Serializable]

    public class ParticipantList {
        public Participant[] participant;
    }

    public ParticipantList myParticipantList = new ParticipantList();


    // Start is called before the first frame update
    void Start() {
        filename = Application.dataPath + "/ratings.csv"; 
    }


    // Update is called once per frame
    void Update() {
        //if (Input.GetKeyDown(KeyCode.Space)) {
            //WriteCSV(); 
        //}
        //if (Input.GetMouseButtonDown(0)) {
            //WriteCSV(); 
        //}
    }

    public void WriteCSV() {
        if (myParticipantList.participant.Length > 0) {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Rating"); // headings of excel spreadsheet.
            tw.Close();

            tw = new StreamWriter(filename, true); // true, because we're appending new data

            for (int i = 0; i < myParticipantList.participant.Length; i++) {
                tw.WriteLine(myParticipantList.participant[i].rating);
            }

            tw.Close();
        }
    }
}
