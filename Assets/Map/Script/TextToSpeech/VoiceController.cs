using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using TMPro;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";

    [SerializeField]
    TextMeshProUGUI text;

    private void Start()
    {
        SetUp(LANG_CODE);

        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;
    }

    #region Text to Speech

    public void StartSpeaking()
    {
        string message = text.text;
        Debug.Log(message);
        TextToSpeech.instance.StartSpeak(message);
    }

    public void StopSpeaking()
    {
        TextToSpeech.instance.StopSpeak();
    }

    void OnSpeakStart()
    {
        Debug.Log("Talking started...");
    }

    void OnSpeakStop()
    {
        Debug.Log("Talking stopped");
    }

    #endregion

    void SetUp(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
    }
}
