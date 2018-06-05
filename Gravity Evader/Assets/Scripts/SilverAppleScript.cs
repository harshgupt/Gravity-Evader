﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverAppleScript : MonoBehaviour {

    public static float speed;

    void Start()
    {
        speed = 0.03f + ((float)(ScoreScript.score / 50) * (0.01f));
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
