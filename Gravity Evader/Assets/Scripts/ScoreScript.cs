using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text scoreObject;
    public static int score;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        scoreObject.text = score.ToString();
    }
}
