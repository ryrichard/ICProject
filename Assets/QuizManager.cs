using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<Question_Answer> QnA;
    public GameObject[] options;
    public int currentQuestion = 0;
    public AnswerScript answerScript;

    public GameObject continueButton;

    public TMP_Text QuestionTxt;

    

    /// < singletone code >
    public static QuizManager quizManager
    {
        get;
        private set;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    /// < end of singleton code > 

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        if (QnA.Count == 1)
        {
            Debug.Log("You Win");
            continueButton.SetActive(true);
        }
        else
        {
            QnA.RemoveAt(currentQuestion);
            generateQuestion();
        }
            
    }

    public void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false; // setting false flag
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i]; //getting question text from QnA

            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true; //sets the correct answer
            }
        }
    }

    public void generateQuestion()
    {
        QuestionTxt.text = QnA[currentQuestion].question;
        setAnswers();
    }
}