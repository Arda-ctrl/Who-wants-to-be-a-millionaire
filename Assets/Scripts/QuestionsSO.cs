using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Questions",fileName ="New Questions")]
public class QuestionsSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter the questions";
    public string GetQuestions()
    {
        return question;
    }
}
