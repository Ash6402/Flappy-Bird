using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone;
    public BirdScript bird;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.isAlive)
        {
            transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
            if (transform.position.x < deadZone)
                Destroy(gameObject);
        }
    }
}
