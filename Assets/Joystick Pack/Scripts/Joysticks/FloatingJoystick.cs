using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    public bool isTapped;

    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        isTapped = true;
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
        Debug.Log(isTapped);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        isTapped = false;
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        Debug.Log(isTapped);
    }
}