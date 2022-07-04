using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public GameObject wrongWindow;
    public AnswerScript answerScript;

    public float time = 5f;

   

    public void Answer()
    {
        if (isCorrect)
        {
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            wrongWindowOpen();
           
           
        }
    }

    public void wrongWindowOpen()
    {
       
        wrongWindow.SetActive(true);

    }

    public void wrongWindowClose()
    {
        
        wrongWindow.SetActive(false);

    }
}