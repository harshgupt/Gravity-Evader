using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {

    public GameObject mainObject;
    public GameObject mainUI;
    public static int highscore;
    public static bool isGameOver;

    private void Start()
    {
        mainUI.SetActive(true);
        highscore = PlayerPrefs.GetInt("Highscore");
        mainObject.GetComponent<AppleSpawner>().enabled = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            OnGameOver();
        }
    }

    public void OnGameStart()
    {
        mainUI.SetActive(false);
        mainObject.GetComponent<AppleSpawner>().enabled = true;
    }

    public void OnGameOver()
    {
        AppleScript.speed = 0;
        SilverAppleScript.speed = 0;
        GoldenAppleScript.speed = 0;
        mainObject.GetComponent<AppleSpawner>().enabled = false;
    }
}
