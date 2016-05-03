using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ParticipantInputField : MonoBehaviour {

    public InputField input;

    void Start()
    {
        Data.Scenes.Add("MainMenu");
    }

    public void SetParticipantName()
    {
        Data.ParticipantsName = input.text;
    }

    public void InitialSceneTime()
    {
        float timeInScene = Time.time;
        Data.InitialSceneTime = timeInScene;
    }
}
