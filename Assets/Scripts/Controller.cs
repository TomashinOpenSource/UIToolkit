using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Game game;
    public UI ui;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        game.InitializeGame();
        UpdateUI();
    }
    
    public void HandleWrongAnswer()
    {
        game.HandleWrongAnswer();
        UpdateUI();
    }
    
    public void HandleCorrectAnswer()
    {
        game.HandleCorrectAnswer();
        UpdateUI();
    }
    
    public void CheckAnswer(string answer)
    {
        if (game.IsAnswerCorrect(answer))
        {
            HandleCorrectAnswer();
            Debug.Log("Answer is correct!");
        }
        else
        {
            HandleWrongAnswer();
            Debug.Log("Answer is wrong!");
        }
    }
    
    public void UpdateUI()
    {
        ui.SetHint(game.getCurrentHint());
        ui.SetHintNum(game.getCurrentHintNum());
        ui.SetQuestionNumber(game.getCurrentQuestionNum());
    }
    
    public List<Question> getAllQuestions()
    {
        return game.questions;
    }
}
