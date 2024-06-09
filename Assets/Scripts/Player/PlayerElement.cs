using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerElement : MonoBehaviour
{
    public ElementType Element { get; private set; } = ElementType.Fire;

    public UnityEvent<ElementType> OnSwitchElement;

    private int selectedElementId = 0;

    private List<ElementType> elements = new() { ElementType.Fire };

    public void NextElement()
    {
        selectedElementId = (selectedElementId + 1) % elements.Count;
        SwitchElement(elements[selectedElementId]);
    }

    public void PreviousElement()
    {
        selectedElementId = (selectedElementId - 1 + elements.Count) % elements.Count;
        SwitchElement(elements[selectedElementId]);
    }

    public void AddElement(ElementType elementType)
    {
        if (!elements.Contains(elementType))
            elements.Add(elementType);
    }

    public void SwitchElement(ElementType type)
    {
        Element = type;
        OnSwitchElement?.Invoke(Element);
    }

    private void Update()
    {
        HandleElementSwitch();
    }

    private void HandleElementSwitch()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
            NextElement();
        else if (scroll < 0f)
            PreviousElement();
    }
}