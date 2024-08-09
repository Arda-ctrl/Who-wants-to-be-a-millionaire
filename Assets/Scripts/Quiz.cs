using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    Image buttonImage;
    [SerializeField] TextMeshProUGUI questionsText;
    [SerializeField] QuestionsSO questions;

    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        GetNextQuestions();
    }
    public void OnAnswerSelected(int index)
    {
        if(index == questions.GetCorrectAnswer())
        {
            questionsText.text = "Well Done";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else 
        {
            correctAnswerIndex = questions.GetCorrectAnswer();
            string correctAnswer = questions.GetAnswer(correctAnswerIndex);
            questionsText.text = "Sorry about that , the correct answer was : \n" + correctAnswer;

            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }    
        SetButtonState(false);
    }
    void GetNextQuestions()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        LoopQuestions();
    }
    void LoopQuestions()
     {
        questionsText.text = questions.GetQuestions();
        for(int i=0;i<4;i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>(); 
            buttonText.text = questions.GetAnswer(i);
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
