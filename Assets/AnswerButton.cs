using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AnswerButton : MonoBehaviour, IPointerDownHandler
{
    //public class Answer
    //{
    //    public string Name { get; set; }
    //    public bool IsCorrect { get; set; }

    //}

    //Answer a1_a;
    //Answer a1_b;
    //Answer a1_c;
    //Answer a1_d;

    public bool isCorrectAnswer;

    bool buttonPressed = false;

    // Use this for initialization
    void Start()
    {
        //a1_a = new Answer { Name = "RUN!", IsCorrect = true };
        //a1_b = new Answer { Name = "Call 777", IsCorrect = false };
        //a1_c = new Answer { Name = "Nothing", IsCorrect = false };
        //a1_d = new Answer { Name = "Something completely stupid", IsCorrect = false };
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnPointerDown(PointerEventData data)
    {
        if (this.isCorrectAnswer == true)
        {
            Data.timesAnswered += 1;
            Data.timesCorrect += 1;
            Debug.Log("The user has answered: " + Data.timesAnswered + " times.");
            Debug.Log("Is correct answer! \n Change scene plz.");
            this.isCorrectAnswer = false;
        }
        else
        {
            Data.timesAnswered += 1;
            Debug.Log("Restart scene and let user try again");
            Debug.Log("The user has answered: " + Data.timesAnswered + "times.");
        }
    }
}
