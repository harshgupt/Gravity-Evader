using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

    public GameObject mainObject;
    public GameObject mainUI;
    public GameObject title;
    public GameObject playButton;
    public GameObject playAgainButton;
    public GameObject highscoreButton;
    public GameObject highscoreScreen;
    public GameObject scoreValue;
    public static bool isGameOver;
    public Animator scoreAnimator;
    public Animator bgAnimator;
    public Animator playButtonAnimator;
    public Animator playAgainButtonAnimator;
    public Animator highscoreButtonAnimator;

    private void Start()
    {
        mainUI.SetActive(true);
        title.SetActive(true);
        playButton.SetActive(true);
        playAgainButton.SetActive(false);
        highscoreButton.SetActive(false);
        mainObject.GetComponent<AppleSpawner>().enabled = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            isGameOver = false;
            OnGameOver();
        }
    }

    public void OnGameStart()
    {
        mainUI.SetActive(false);
        title.SetActive(false);
        playButton.SetActive(false);
        mainObject.GetComponent<AppleSpawner>().enabled = true;
    }

    public void OnGameOver()
    {
        AppleScript.speed = 0;
        SilverAppleScript.speed = 0;
        GoldenAppleScript.speed = 0;
        mainObject.GetComponent<AppleSpawner>().enabled = false;
        scoreAnimator.SetTrigger("GameOver");
        bgAnimator.SetTrigger("GameOver");
        playAgainButton.SetActive(true);
        highscoreButton.SetActive(true);
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnHighscoreClick()
    {
        mainUI.SetActive(true);
        highscoreScreen.SetActive(true);
        highscoreButton.SetActive(false);
        scoreValue.SetActive(false);
        playAgainButton.SetActive(true);
        playAgainButtonAnimator.SetTrigger("HighscoreClick");
    }
}
