using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

    public Text question;

    public GameObject correctAnswerWindow;
    public GameObject wrongAnswerWindow;

    public bool windowActive = false;

    public string nextScene;

    public void CorrectAnswer()
    {
        // Checks if window
        if (correctAnswerWindow.activeSelf == false & windowActive == false)
        {
            // Show window to proceed to next question/challenge
            correctAnswerWindow.SetActive(true);
            windowActive = true;
            // Increment times answered and correct
            //Data.timesAnswered += 1;
            //Data.timesCorrect += 1;
            
            // Add correct answer to the List of correct answers
            //Data.correctAnswers.Add(question.text);
        }
    }

    public void WrongAnswer()
    {
        if (wrongAnswerWindow.activeSelf == false & windowActive == false)
        {
            // Show wrong window - try again
            wrongAnswerWindow.SetActive(true);
            windowActive = true;
            // Increment times answered
            //Data.timesAnswered += 1;

            // Add wrong answer to List of wrong answers
            //Data.wrongAnswers.Add(question.text);
        }
    }

    public void NextScene()
    {
        // Change to next scene. Please write the scene name in the Inspector.
        SceneManager.LoadScene(nextScene);
    }


    // Close wrong answer window
    public void CloseWrongAnswerWindow()
    {
        wrongAnswerWindow.SetActive(false);
        windowActive = false;
    }
}
