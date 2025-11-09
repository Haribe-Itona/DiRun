using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public Action OnPress;
    public Action OnHold;

    public Action OnRelease;
    public Action OnClick;
    public float holdTime = 0;
    public bool run = false;

    public void OnPointerDown(PointerEventData eventData)
	{
        if (holdTime == 0)
        {
            OnPress?.Invoke();
            Debug.Log("OnPress");
            run = true;
            return;
        }

	}

    public void OnPointerUp(PointerEventData eventData)
    {
        OnRelease?.Invoke();
  
        holdTime = 0;
        run = false;
    }
    public void Hold()
    {
        OnHold?.Invoke();
        Debug.Log("OnHold");
        holdTime += 1;
    }
}