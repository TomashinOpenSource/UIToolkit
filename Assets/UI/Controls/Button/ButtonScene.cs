using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ButtonScene : MonoBehaviour
{
    private VisualElement box;
    private Button button; 
    
    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        box = root.Q("Box");
        button = root.Q<Button>("Button");
        
        button.clicked += OnButtonClicked;
    }
    private void OnButtonClicked()
    {
        Debug.Log("OnButtonClicked");
        box.style.width = Random.Range(50, 300);
        box.style.height = Random.Range(50, 300);
    }
}
