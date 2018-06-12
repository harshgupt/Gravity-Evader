using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public GameObject player;
    public static float speed = 0f;
    public AudioSource audioSource;
    public AudioClip appleHit;
    public AudioClip goldCollect;
    public AudioClip silverCollect;
    public AudioClip appleSplat;

    void Update ()
    {
		if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
                touchedPos.y = -4f;
                if(touchedPos.x >= -2.8f && touchedPos.x <= 2.8f)
                {
                    transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * speed);
                }
                else if(touchedPos.x < -2.8f)
                {
                    Vector3 leftLimit = new Vector3(-2.8f, -4f, 0);
                    transform.position = Vector3.Lerp(transform.position, leftLimit, Time.deltaTime * speed);
                }
                else if(touchedPos.x > 2.8f)
                {
                    Vector3 rightLimit = new Vector3(2.8f, -4f, 0);
                    transform.position = Vector3.Lerp(transform.position, rightLimit, Time.deltaTime * speed);
                }
            }
        }
        if (AppleScript.playAudio)
        {
            AppleScript.playAudio = false;
            audioSource.PlayOneShot(appleSplat);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Apple")
        {
            speed = 0;
            audioSource.PlayOneShot(appleHit);
            MainScript.isGameOver = true;
            //collision.gameObject.transform.parent = transform;
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            collision.tag = "Untagged";
            
        }
        else if (collision.gameObject.tag == "Silver Apple")
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(silverCollect);
            OnSilverApple();
        }
        else if(collision.gameObject.tag == "Golden Apple")
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(goldCollect);
            OnGoldenApple();
        }
    }

    void OnSilverApple()
    {
        ScoreScript.score += 5;
    }

    void OnGoldenApple()
    {
        ScoreScript.score += 10;
    }
}
