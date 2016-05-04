using UnityEngine;
using System.Collections;

public class TestRotation : MonoBehaviour {
    Vector2 position;
    // Use this for initialization
    Quaternion startRotation;
    Quaternion rot;

    public float lerpTime = 1f;
    float currentLerpTime;


    void Start () {
         position = gameObject.GetComponent<RectTransform>().anchoredPosition;
        startRotation = gameObject.GetComponent<RectTransform>().rotation;

        currentLerpTime = 0;
        rot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        position = gameObject.GetComponent<RectTransform>().anchoredPosition;
        if (Input.GetKeyDown("space"))
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0.001f);
        }

        float z = rot.eulerAngles.z;

        z = 184;

        rot = Quaternion.Euler(0, 0, z);

        
        //transform.rotation = rot;
        if (position.y > 0)
        {
            currentLerpTime += Time.deltaTime;

            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float perc = currentLerpTime / lerpTime;
            gameObject.GetComponent<RectTransform>().rotation = Quaternion.Lerp(startRotation, rot, perc);
           // gameObject.GetComponent<RectTransform>().rotation = rot;
        }
	}
}
