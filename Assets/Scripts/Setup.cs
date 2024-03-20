using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Setup
{
    public static void Initialize(VisualElement root)
    {
        InitializeDragDrop(root);
        InitializeIcons(root);
    }

    static void InitializeDragDrop(VisualElement root)
    {
        root.Query<VisualElement>("IconBoard")
            .Children<VisualElement>()
            .ForEach(elem =>
            {
                elem.AddManipulator(new IconDragger(root));
            });
    }

    static void InitializeIcons(VisualElement root)
    {
        
    }
}
