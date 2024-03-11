using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SliderScene : MonoBehaviour
{
    private VisualElement box;
    private Slider _slider;
    
    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;
        
        box = root.Q<VisualElement>("Box");
        _slider = root.Q<Slider>("MySlider");
        
        _slider.RegisterValueChangedCallback(OnSliderValueChanged);
    }
    private void OnSliderValueChanged(ChangeEvent<float> evt)
    {
        box.style.width = evt.newValue * 10;
    }
}
