using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public Controller controller;
    
    VisualElement root;
    Label hint;
    Label hintNumLabel;
    Label questionNumLabel;
    Label timeLabel;
    Label answer_indicator;
    Label highscoreLabel;
    Label currentscoreLabel;
    Button nextHintButton;
    
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        
        hint = root.Q<Label>("Hint");
        hintNumLabel = root.Q<Label>("HintNum");
        questionNumLabel = root.Q<Label>("QuestionCounter");
        nextHintButton = root.Q<Button>("NextHintButton");
        timeLabel = root.Q<Label>("CounterLabel");
        answer_indicator = root.Q<Label>("AnswerIndicator");
        highscoreLabel = root.Q<Label>("Highscore");
        currentscoreLabel = root.Q<Label>("Myscore");

        Initialize();
    }
    private void Initialize()
    {
        nextHintButton.clicked += () =>
        {
            controller.HandleWrongAnswer();
        };
    }

    public void SetHint(string hintText)
    {
        hint.text = hintText;
    }
    public void SetHintNum(int hintNum)
    {
        hintNumLabel.text = "Hint " + hintNum.ToString() + ":";
    }
    public void SetQuestionNumber(int questionNum)
    {
        questionNumLabel.text = "Question " + questionNum.ToString();
    }
}
