using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public LogicScript logic;
    public float flapStrength;
    public bool isAlive = true;
    public float flapRotationSpeed;
    private float _y; 
    private float _rotateSpeed = -2f;
    private AudioSource _flapAudio;
    // Start is called before the first frame update
    private void Start()
    {
        _flapAudio = GetComponent<AudioSource>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        _y = transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            rigidbody.velocity = Vector2.up * flapStrength;
            _flapAudio.Play();
        }

        if (_y > transform.position.y)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -60)),
            _rotateSpeed * Time.deltaTime);
            _rotateSpeed += 0.35f;
        }
        else if(_y < transform.position.y)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 30), flapRotationSpeed * Time.deltaTime);
            _rotateSpeed = -2f;
        }
        _y = transform.position.y;
    }

    public void OnCollisionEnter2D()
    {
        logic.GameOver();
        isAlive = false;
    }
}
