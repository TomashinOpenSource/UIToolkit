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
        root = GetComponent<UIDocument>().rootVisualElement;
        
        hint = root.Q<Label>("Hint");
        hintNumLabel = root.Q<Label>("HintNum");
        questionNumLabel = root.Q<Label>("QuestionCounter");
        nextHintButton = root.Q<Button>("NextHintButton");
        timeLabel = root.Q<Label>("CounterLabel");
        answer_indicator = root.Q<Label>("AnswerIndicator");
        highscoreLabel = root.Q<Label>("Highscore");
        currentscoreLabel = root.Q<Label>("Myscore");
        
        answer_indicator.style.visibility = Visibility.Hidden;

        Initialize();
    }
    private void Initialize()
    {
        nextHintButton.clicked += () =>
        {
            controller.HandleWrongAnswer();
        };
        Setup.InitializeDragDrop(root, controller);
        Setup.InitializeIcons(root, controller.getAllQuestions());
    }
    
    public void GiveAnswerFeedback(bool isCorrect)
    {
        answer_indicator.style.visibility = Visibility.Visible;
        answer_indicator.text = isCorrect ? "Your answer was correct!" : "Your answer was wrong!";

        StyleColor colorCorrect = new StyleColor(new Color32(0, 132, 19, 255));
        StyleColor colorWrong = new StyleColor(new Color32(132, 0, 19, 255));

        answer_indicator.style.color = isCorrect ? colorCorrect : colorWrong;
        
        StartCoroutine(CleanUpQuestion());
    }
    private IEnumerator CleanUpQuestion()
    {
        yield return new WaitForSeconds(3);
        answer_indicator.style.visibility = Visibility.Hidden;
        VisualElement dropZone = root.Q("DropBox");
        if (dropZone.childCount > 0)
        {
            dropZone.RemoveAt(0);
        }
    }

    public void SetTimer(string seconds)
    {
        timeLabel.text = seconds + " seconds left";
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
