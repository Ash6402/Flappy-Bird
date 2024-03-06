using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone;
    public BirdScript bird;
    // Start is called before the first frame update
    private void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!bird.isAlive) return;
        transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
        if (transform.position.x < deadZone)
            Destroy(gameObject);
    }
}
