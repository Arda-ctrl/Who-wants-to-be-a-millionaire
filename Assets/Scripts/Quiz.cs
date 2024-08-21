using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    
    Image buttonImage;
    [Header("------------Questions------------")]

    [SerializeField] TextMeshProUGUI questionsText;
    [SerializeField] List<QuestionsSO> questions = new List<QuestionsSO>();
    QuestionsSO currentQuestions;
    [Header("-------------Answers-------------")]

    [SerializeField] GameObject[] answerButtons;
    bool hasAnsweredEarly = true;
    int correctAnswerIndex;
    [Header("-------------Sprites-------------")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("--------------Time--------------")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("-------------Scoring-------------")]
    [SerializeField]  TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("--------------Slider--------------")]
    [SerializeField] Slider progressBar;
    public bool isComplate;
    



    void Awake()
    {
        timer = FindAnyObjectByType<Timer>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        
    }
    void Update() 
    {
        timerImage.fillAmount = timer.fillFraciton;
        if(timer.isLoadNextQuestion)
        {
            if(progressBar.value == progressBar.maxValue)
        {
            isComplate = true;
            return;
        }
            hasAnsweredEarly = false;
            GetNextQuestions();
            timer.isLoadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score : " + scoreKeeper.CalculuteScore() + "%";
        
    }
    void DisplayAnswer(int index)
    {
        if(index == currentQuestions.GetCorrectAnswer())
        {
            questionsText.text = "Well Done";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswer();

        }
        else 
        {
            correctAnswerIndex = currentQuestions.GetCorrectAnswer();
            string correctAnswer = currentQuestions.GetAnswer(correctAnswerIndex);
            questionsText.text = "Sorry about that , the correct answer was : \n" + correctAnswer;

            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
    void GetNextQuestions()
    {
        if(questions.Count > 0)
        {
        SetButtonState(true);
        GetRandomQuestions();
        SetDefaultButtonSprites();
        LoopQuestions();
        progressBar.value++;
        scoreKeeper.IncrementQuestionCount();
        }
    }
    void GetRandomQuestions()
    {
        int index = Random.Range(0,questions.Count);
        currentQuestions = questions[index];
        //if(questions.Contains(currentQuestions))
        //{
            questions.Remove(currentQuestions);
        //}
    }
    void LoopQuestions()
     {
        questionsText.text = currentQuestions.GetQuestions();
        for(int i=0;i<4;i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>(); 
            buttonText.text = currentQuestions.GetAnswer(i);
        }
     }
     void SetButtonState(bool state)
     {
            for(int i =0;i<answerButtons.Length;i++)
            {
                Button button = answerButtons[i].GetComponent<Button>();
                button.interactable = state;
            }
     }
     void SetDefaultButtonSprites()
     {
          
        for(int i=0;i<answerButtons.Length;i++)
        {
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
            
        }
     }

   
}
