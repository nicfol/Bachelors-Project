using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonCorrect : MonoBehaviour, IPointerDownHandler
{
    public Text question;

    public GameObject windowAnswerObject;
    private WindowAnswer windowAnswer;

    // Use this for initialization
    void Start()
    {
        windowAnswer = windowAnswerObject.GetComponent<WindowAnswer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData data)
    {
        if (windowAnswer.windowIsActive == false)
        {
            
            windowAnswer.Show();
            Data.timesAnswered += 1;
            Data.timesCorrect += 1;
            Debug.Log("The user has answered: " + Data.timesAnswered + " times.");
            Debug.Log("Is correct answer! \n Change scene plz.");

            Data.correctAnswers.Add(question.text);
            windowAnswer.windowIsActive = true;
               
        }
    }
}