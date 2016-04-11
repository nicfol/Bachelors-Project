using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour, IPointerDownHandler{
    public string nextScene;

    public void OnPointerDown(PointerEventData data)
    {
        SceneManager.LoadScene(nextScene);
    }
}