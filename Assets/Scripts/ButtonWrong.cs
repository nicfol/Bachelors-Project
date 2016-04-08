using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonWrong : MonoBehaviour, IPointerDownHandler
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
            Debug.Log("Restart scene and let user try again");
            Debug.Log("The user has answered: " + Data.timesAnswered + " times.");
            Data.wrongAnswers.Add(question.text);
            windowAnswer.windowIsActive = true;
        }
    }
}
