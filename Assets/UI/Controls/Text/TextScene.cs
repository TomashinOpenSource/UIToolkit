using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

public class TextScene : MonoBehaviour
{
    private Label _label;
    
    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        _label = root.Q<Label>("MyLabel");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("GetKeyDown");
            _label.text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }
    }
}
