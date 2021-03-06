﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementPopup : MonoBehaviour {

    public Text achievementText;
    public GameObject achievementBoxContainer;

    public bool dropWindow = false;
    
    bool achievementBoxIsActive = false;

    public RectTransform target;
    private Vector2 normalPosition;
    float step;
    public float speed = 500;

    public void DisplayPopup(string achievementName) 
    {
        if(!dropWindow) {
            achievementBoxContainer.SetActive(true);
            StartCoroutine("DropWindow");
            achievementText.text = achievementName;
        } else {
            StartCoroutine(wait4Seconds(achievementName));
        }
    }
    
    IEnumerator wait4Seconds(string achievementName){
        yield return new WaitForSeconds(6);
        DisplayPopup(achievementName);
    }

    IEnumerator DropWindow()
    {
        achievementBoxIsActive = true;

        dropWindow = true;

        yield return new WaitForSeconds(4);

        dropWindow = false;

        yield return null;
    }

    // Use this for initialization
    void Start () {
        normalPosition = achievementBoxContainer.GetComponent<RectTransform>().anchoredPosition;
    }
	
	// Update is called once per frame
	void Update () {

        step = speed * Time.deltaTime;

        if (dropWindow)
        {
            achievementBoxContainer.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(achievementBoxContainer.GetComponent<RectTransform>().anchoredPosition, target.anchoredPosition,step);
        }
        else
        {
            achievementBoxContainer.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(achievementBoxContainer.GetComponent<RectTransform>().anchoredPosition, normalPosition, step);
        }
    }
}
