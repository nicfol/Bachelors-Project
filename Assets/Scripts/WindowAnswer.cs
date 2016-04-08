using UnityEngine;
using System.Collections;

public class WindowAnswer : MonoBehaviour {

    public bool windowIsActive = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
