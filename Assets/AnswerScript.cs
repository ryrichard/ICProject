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
            StartCoroutine(correct());
        }
        else
        {
            Debug.Log("Wrong Answer");
            wrongWindowOpen();
            
        }
    }

    public void wrongWindowOpen()
    {
        StartCoroutine(wrongWindowPanel());
    }

    IEnumerator correct()
    {
        gameObject.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Image>().color = Color.white;
        quizManager.correct();
    }

    IEnumerator wrongWindowPanel()
    {
        wrongWindow.SetActive(true);
        yield return new WaitForSeconds(3);
        wrongWindow.SetActive(false);
    }

}