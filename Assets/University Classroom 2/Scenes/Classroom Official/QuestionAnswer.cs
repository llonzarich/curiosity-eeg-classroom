using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using static System.Console;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using TMPro;


public class QuestionAnswer : MonoBehaviour
{
    Dictionary<string, ArrayList> questionList = new Dictionary<string, ArrayList>(){
            {"question", new ArrayList() },
            { "answer",  new ArrayList() }
        };

    Dictionary<string, ArrayList> returnList = new Dictionary<string, ArrayList>(){
            {"number", new ArrayList() },
            {"answer",  new ArrayList() },
            {"question",  new ArrayList() }
        };

    int numOfQuest = 0;

    string questionText;
    string answerText;

    [SerializeField]
    GameObject questionAnswer;


    // Start is called before the first frame update
    void Start()
    {
        StreamReader readFile = new StreamReader("C://Users//smeronek//Downloads//question_answer.csv");
        string line;
        string[] row;
        readFile.ReadLine();
        while ((line = readFile.ReadLine()) != null)
        {
            row = line.Split(',');
            string question = (row[0]);
            string answer = (row[1]);

            questionList["question"].Add(question);
            questionList["answer"].Add(answer);
        }
        readFile.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getQuestionAnswer()
    {

        questionText = questionList["question"][numOfQuest].ToString();
        answerText = questionList["answer"][numOfQuest].ToString();

        returnList["question"].Add(questionText);
        returnList["answer"].Add(answerText);
        returnList["number"].Add(numOfQuest + 1);

        questionList["question"].RemoveAt(numOfQuest);
        questionList["answer"].RemoveAt(numOfQuest);

        numOfQuest += 1;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        questionAnswer.SetActive(false);

        if (other.gameObject.name == "Cube_1s")
        {
            getQuestionAnswer();
            questionAnswer.GetComponent<TMPro.TextMeshProUGUI>().text = questionText;

        }
        else
        {
            questionAnswer.GetComponent<TMPro.TextMeshProUGUI>().text = answerText;
            
        }

        



    }

    private void OnTriggerExit(Collider other)
    {

        questionAnswer.SetActive(true);
    }


}
