using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System.IO;

[System.Serializable]
public class QuizQuestion
{
    public string question;
    public string[] answers;
    public string correctAnswer;
}

[System.Serializable]
public class QuizData
{
    public List<QuizQuestion> questions;
}

public class QuizManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text questionText;         
    public Button[] answerButtons;        
    public GameObject quizPanel;          

    [Header("JSON")]
    public string jsonFileName = "quiz.json";

    [Header("VR Input")]
    public InputActionProperty openQuizAction;   
    public InputActionProperty closeQuizAction;  

    private QuizData quizData;

    void Start()
    {
        LoadQuizData();

        openQuizAction.action.Enable();
        closeQuizAction.action.Enable();

        if (quizPanel != null)
            quizPanel.SetActive(false);
    }

    void Update()
    {

        if (openQuizAction != null &&
            openQuizAction.action != null &&
            openQuizAction.action.WasPressedThisFrame())
        {
            Debug.Log("Open Quiz");
            ShowQuizPanel();
        }


        if (closeQuizAction != null &&
            closeQuizAction.action != null &&
            closeQuizAction.action.WasPressedThisFrame())
        {
            Debug.Log("Hide Quiz");
            HideQuizPanel();
        }
    }

    void LoadQuizData()
    {
        TextAsset jsonText = Resources.Load<TextAsset>(Path.GetFileNameWithoutExtension(jsonFileName));
        if (jsonText != null)
        {
            quizData = JsonUtility.FromJson<QuizData>(jsonText.text);
        }
        else
        {
            Debug.LogError("Can't find file JSON in Resources!");
        }
    }

    public void ShowRandomQuestion()
    {
        if (quizData != null && quizData.questions.Count > 0)
        {
            int randomIndex = Random.Range(0, quizData.questions.Count);
            QuizQuestion q = quizData.questions[randomIndex];

            if (questionText != null)
                questionText.text = q.question;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < q.answers.Length)
                {
                    TMP_Text btnText = answerButtons[i].GetComponentInChildren<TMP_Text>();
                    btnText.text = q.answers[i];
                    answerButtons[i].gameObject.SetActive(true);
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }

    [ContextMenu("Show Quiz Panel")]
    public void ShowQuizPanel()
    {
        if (quizPanel != null)
        {
            quizPanel.SetActive(true);
            ShowRandomQuestion(); 
        }
    }

    void HideQuizPanel()
    {
        if (quizPanel != null)
            quizPanel.SetActive(false);
    }
}