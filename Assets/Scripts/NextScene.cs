using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour, IPointerDownHandler
{
    public Object nextScene;

    public void OnPointerDown(PointerEventData data)
    {
        SceneManager.LoadScene(nextScene.name);
    }
}