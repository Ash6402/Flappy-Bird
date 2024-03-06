using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate, timer = 0;
    public BirdScript bird;
    // Start is called before the first frame update
    private void Start()
    {
        Spawn();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!bird.isAlive) return;
        if (timer < spawnRate)
            timer += Time.deltaTime;
        else
        {
            Spawn();
            timer = 0;
        }
    }

    private void Spawn()
    {
        const float lowest = -1f, highest = 15f;
        Instantiate(pipe, new Vector3(
            transform.position.x,
            Random.Range(lowest, highest)
            ),transform.rotation
        );
    }
}
