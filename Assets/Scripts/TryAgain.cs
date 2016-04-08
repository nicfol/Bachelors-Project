using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TryAgain : MonoBehaviour, IPointerDownHandler
{
    public WindowAnswer windowAnswer;
    public void OnPointerDown(PointerEventData data)
    {
        windowAnswer.windowIsActive = false;
        windowAnswer.Close();
        
    }
}
