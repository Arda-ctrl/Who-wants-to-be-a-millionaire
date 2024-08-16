using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToComplateQuestions = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool isAnsweringQuestion = false;
    public bool isLoadNextQuestion = false;

    float timerValue;
    public float fillFraciton;
    void Update()
    {
        UpdateTimer();
    }
    public void CancelTimer()
    {
        timerValue = 0;
    }
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timerValue <= 0)
            {
                timerValue = timeToShowCorrectAnswer;
            }
            else
            {
                    fillFraciton=timerValue/timeToComplateQuestions;
            }
        }
        else
        {
            if(timerValue<=0)
        {
            isAnsweringQuestion = true;
            isLoadNextQuestion = true;
            timerValue = timeToComplateQuestions;
        }
        else
        {
            fillFraciton = timerValue/timeToShowCorrectAnswer;
        }
        }
        Debug.Log(isAnsweringQuestion + " : "+timerValue+" = "+fillFraciton);
    }
}
