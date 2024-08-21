using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndScreen : MonoBehaviour
{
    [Header("-------------Scoring-------------")]
    [SerializeField]  TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    void Awake() {
     scoreKeeper = FindAnyObjectByType<ScoreKeeper>();   
    }
    public void ShowFinalScore()
    {
        finalScoreText.text = "Congrulations Your Score Is " + scoreKeeper.CalculuteScore() + "%";
    }
}
