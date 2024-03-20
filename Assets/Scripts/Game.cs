using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Question> questions = new List<Question>();
    
    Question currentQuestion;
    int questionIndex = 0;

    private string currentHint;
    int hintIndex = 0;

    public void InitializeGame()
    {
        currentQuestion = questions[questionIndex];
        currentHint = currentQuestion.GetHints()[hintIndex];
    }
}
