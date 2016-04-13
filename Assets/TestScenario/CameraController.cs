using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	void Start () {
	    StartCoroutine("moveCamera");
	}
    
	void Update () {
	
	}
    
    public float transitionDuration = 2.5f;
    public Transform target;
    IEnumerator moveCamera() {
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        while (t < 1.0f) {
            t += Time.deltaTime * (Time.timeScale/transitionDuration);
            Camera.main.transform.position = Vector3.Lerp(startingPos, target.position, t);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5, t/20);
            yield return 0;
        }
    }
}
