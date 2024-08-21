using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionsSeen = 0;
    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }
    public void IncrementCorrectAnswer()
    {
        correctAnswers++;
    }
    public int QuestionCount()
    {
        return questionsSeen;      
    }
    public void IncrementQuestionCount()
    {
        questionsSeen++;
    }
    public int CalculuteScore()
    {
        return Mathf.RoundToInt(correctAnswers / (float)questionsSeen*100);
    }
    }
    

