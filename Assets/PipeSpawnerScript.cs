using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate, timer = 0;
    public BirdScript bird;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.isAlive)
        {
            if (timer < spawnRate)
                timer += Time.deltaTime;
            else
            {
                spawn();
                timer = 0;
            }
        }
    }

    void spawn()
    {
        float lowest = -1, highest = 15;
        Instantiate(pipe, new Vector3(
            transform.position.x,
            Random.Range(lowest, highest)
            ),transform.rotation
        );
    }
}
