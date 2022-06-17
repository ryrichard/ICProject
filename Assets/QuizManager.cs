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

    public TMP_Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        if (currentQuestion < 0)
        {
            Debug.Log("You Win");
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
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];

            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void generateQuestion()
    {
        QuestionTxt.text = QnA[currentQuestion].question;
        setAnswers();


    }
}