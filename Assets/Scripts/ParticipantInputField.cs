using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ParticipantInputField : MonoBehaviour {

    public InputField input;

    public void SetParticipantName()
    {
        Data.ParticipantsName = input.text;
    }

}
