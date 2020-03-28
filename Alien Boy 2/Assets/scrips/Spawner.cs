using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject sezer;
    public GameObject coin;

    private float min_X = -2.3f;
    private float max_X = 2.3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
        
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(1f, 0.5f));
        GameObject k;
        if (Random.Range(0f, 10f) > 5)
        {
            k = Instantiate(sezer);
        }
        else
        {
            k = Instantiate(coin);
        }
        k.transform.position = new Vector2(Random.Range(min_X, max_X), transform.position.y);
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
