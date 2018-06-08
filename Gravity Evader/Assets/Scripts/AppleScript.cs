﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour {

    public static float speed;
    
	void Start ()
    {
        speed = 0.2f + ((ScoreScript.score / 25) * (0.02f));
    }
	
	void Update ()
    {
        if (!MainScript.isGameOver)
        {
            transform.Translate(Vector3.down * speed);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
            ScoreScript.score += 1;
        }
    }
}
