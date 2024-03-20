using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class IconDragger : MouseManipulator
{
    private Controller controller;
    
    private Vector2 startPos;
    private Vector2 elemStartPosGlobal;
    private Vector2 elemStartPosLocal;
    
    private VisualElement dragArea;
    private VisualElement iconContainer;
    private VisualElement dropZone;

    private bool isActive;
    
    public IconDragger(VisualElement root, Controller controller)
    {
        this.controller = controller;
        
        dragArea = root.Q("DragArea");
        dropZone = root.Q("DropBox");

        isActive = false;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
        target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
        target.RegisterCallback<MouseUpEvent>(OnMouseUp);
    }
    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
        target.UnregisterCallback<MouseMoveEvent>(OnMouseMove);
        target.UnregisterCallback<MouseUpEvent>(OnMouseUp);
    }

    private void OnMouseDown(MouseDownEvent evt)
    {
        iconContainer = target.parent;
        
        startPos = evt.localMousePosition;
        
        elemStartPosGlobal = target.worldBound.position;
        elemStartPosLocal = target.layout.position;

        dragArea.style.display = DisplayStyle.Flex;
        dragArea.Add(target);

        target.style.top = elemStartPosGlobal.y;
        target.style.left = elemStartPosGlobal.x;

        isActive = true;
        target.CaptureMouse();
        evt.StopPropagation();
    }
    private void OnMouseMove(MouseMoveEvent evt)
    {
        if (!isActive || !target.HasMouseCapture()) return;
        
        var diff = evt.localMousePosition - startPos;
        
        target.style.top = target.layout.y + diff.y;
        target.style.left = target.layout.x + diff.x;
        
        evt.StopPropagation();
    }
    private void OnMouseUp(MouseUpEvent evt)
    {
        if (!isActive || !target.HasMouseCapture()) return;
        
        if (target.worldBound.Overlaps(dropZone.worldBound))
        {
            dropZone.Add(target);
            
            target.style.top = dropZone.contentRect.center.y - target.layout.height / 2;
            target.style.left = dropZone.contentRect.center.x - target.layout.width / 2;
            
            Debug.Log("The provided answer is: " + ((Question)target.userData).display_answer);
            controller.CheckAnswer(((Question)target.userData).answer);
        }
        else
        {
            iconContainer.Add(target);
        
            target.style.top = elemStartPosLocal.y - iconContainer.contentRect.position.y;
            target.style.left = elemStartPosLocal.x - iconContainer.contentRect.position.x;
        }

        isActive = false;
        target.ReleaseMouse();
        evt.StopPropagation();
        
        dragArea.style.display = DisplayStyle.None;
    }
}
