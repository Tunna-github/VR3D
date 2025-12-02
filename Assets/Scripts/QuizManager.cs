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

    [Header("Quiz Settings")]
    public int questionsPerSet = 5;              

    private QuizData quizData;
    private QuizQuestion currentQuestion;

  
    private List<QuizQuestion> currentQuestionSet = new List<QuizQuestion>();
    private int currentQuestionIndex = 0;

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
            Debug.Log("Primary pressed");

            if (quizPanel != null && !quizPanel.activeSelf)
            {
               
                StartNewQuestionSetAndShowPanel();
            }
            else
            {
               
                ShowNextQuestionInSet();
            }
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

 
    void StartNewQuestionSetAndShowPanel()
    {
        if (quizData == null || quizData.questions == null || quizData.questions.Count == 0)
        {
            Debug.LogWarning("No quiz data loaded!");
            return;
        }

      
        currentQuestionSet = GetRandomQuestionSet(questionsPerSet);
        currentQuestionIndex = 0;

        if (quizPanel != null)
        {
            ChangePOV.Instance.ChangeToOriginalPOV();
            quizPanel.SetActive(true);
        }

        ShowQuestion(currentQuestionSet[currentQuestionIndex]);
    }

    
    List<QuizQuestion> GetRandomQuestionSet(int count)
    {
        List<QuizQuestion> pool = new List<QuizQuestion>(quizData.questions);
        List<QuizQuestion> result = new List<QuizQuestion>();

        int n = Mathf.Min(count, pool.Count);

        for (int i = 0; i < n; i++)
        {
            int randomIndex = Random.Range(0, pool.Count);
            result.Add(pool[randomIndex]);
            pool.RemoveAt(randomIndex); 
        }

        return result;
    }


    void ShowNextQuestionInSet()
    {
        if (currentQuestionSet == null || currentQuestionSet.Count == 0)
        {
            Debug.Log("No current question set, creating a new one.");
            StartNewQuestionSetAndShowPanel();
            return;
        }

        
        if (currentQuestionIndex < currentQuestionSet.Count - 1)
        {
            currentQuestionIndex++;
            ShowQuestion(currentQuestionSet[currentQuestionIndex]);
        }
        else
        {
            
            Debug.Log("Finished all questions in current set. Closing quiz panel.");
            HideQuizPanel();
            currentQuestionSet.Clear();      
        }
    }


    void ShowQuestion(QuizQuestion question)
    {
        if (question == null) return;

        currentQuestion = question;

        if (questionText != null)
            questionText.text = currentQuestion.question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button btn = answerButtons[i];

            if (i < currentQuestion.answers.Length)
            {
                TMP_Text btnText = btn.GetComponentInChildren<TMP_Text>();
                if (btnText != null)
                    btnText.text = currentQuestion.answers[i];

                btn.gameObject.SetActive(true);

                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => CheckAnswer(btn));
            }
            else
            {
                btn.gameObject.SetActive(false);
            }

            Image img = btn.GetComponent<Image>();
            if (img != null)
                img.color = Color.white;

            btn.interactable = true;
        }
    }

    private void CheckAnswer(Button selectedButton)
    {
        string playerAnswer = selectedButton.GetComponentInChildren<TMP_Text>().text;
        bool isCorrect = playerAnswer == currentQuestion.correctAnswer;

        Image selectedImg = selectedButton.GetComponent<Image>();

        if (isCorrect)
        {
            if (selectedImg != null)
                selectedImg.color = Color.green;
        }
        else
        {
            if (selectedImg != null)
                selectedImg.color = Color.red;

            foreach (Button btn in answerButtons)
            {
                TMP_Text t = btn.GetComponentInChildren<TMP_Text>();
                if (t != null && t.text == currentQuestion.correctAnswer)
                {
                    Image img = btn.GetComponent<Image>();
                    if (img != null)
                        img.color = Color.green;
                    break;
                }
            }
        }

        foreach (Button btn in answerButtons)
        {
            btn.interactable = false;
        }
    }

    
    [ContextMenu("Show Quiz Panel")]
    public void ShowQuizPanel()
    {
        StartNewQuestionSetAndShowPanel();
    }

    public void HideQuizPanel()
    {
        if (quizPanel != null)
            quizPanel.SetActive(false);
    }
}