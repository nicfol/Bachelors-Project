using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	void Start () {
	    StartCoroutine("Transition");
	}
    
	void Update () {
	
	}
    
    public float transitionDuration = 2.5f;
    public Transform target;
    IEnumerator Transition() {
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        while (t < 1.0f) {
            t += Time.deltaTime * (Time.timeScale/transitionDuration);
            transform.position = Vector3.Lerp(startingPos, target.position, t);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 5, t);
            yield return 0;
        }
    }
}
