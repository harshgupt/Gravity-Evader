using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour {

    public Transform apple;
    public Transform silverApple;
    public Transform goldenApple;

	void Start ()
    {
        InvokeRepeating("SpawnApple", 1f, 2.1f);
        InvokeRepeating("SpawnSilverApple", 10f, 15.1f);
        InvokeRepeating("SpawnGoldenApple", 30f, 35.1f);
    }

    private void Update()
    {
        if (MainScript.isGameOver)
        {
            CancelInvoke("SpawnApple");
            CancelInvoke("SpawnSilverApple");
            CancelInvoke("SpawnGoldenApple");
        }
    }

    void SpawnApple()
    {
        if (!MainScript.isGameOver)
        {
            float randX = Random.Range(-2.5f, 2.5f);
            Vector3 position = new Vector3(randX, 5.5f);
            Instantiate(apple, position, Quaternion.identity);
        }
    }

    void SpawnSilverApple()
    {
        if (!MainScript.isGameOver)
        {
            float randX = Random.Range(-2.5f, 2.5f);
            Vector3 position = new Vector3(randX, 5.5f);
            Instantiate(silverApple, position, Quaternion.identity);
        }
    }

    void SpawnGoldenApple()
    {
        if (!MainScript.isGameOver)
        {
            float randX = Random.Range(-2.5f, 2.5f);
            Vector3 position = new Vector3(randX, 5.5f);
            Instantiate(goldenApple, position, Quaternion.identity);
        }
    }
}
