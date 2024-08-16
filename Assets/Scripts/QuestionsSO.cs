using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Questions",fileName ="New Questions")]
public class QuestionsSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter the questions";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswer;
    //look at the data base
    public string GetQuestions()
    {
        return question;
    }
    public string GetAnswer(int index)
    {
        return answers[index];
    }
    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }
}
