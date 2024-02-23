using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public LogicScript logic;
    public float flapStrength;
    public bool isAlive = true;
    public float dropRotationSpeed;
    public float flapRotationSpeed;
    private float _timer = 0.6f;
    private bool _run;
    private float _y;

    private AudioSource flapAudio;
    // Start is called before the first frame update
    void Start()
    {
        flapAudio = GetComponent<AudioSource>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        _y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            rigidbody.velocity = Vector2.up * flapStrength;
            flapAudio.Play();
            _run = false;
            _timer = 0;
        }

        if (_y > transform.position.y && _run)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -60)),
            dropRotationSpeed * Time.deltaTime);
        }
        else if(_y < transform.position.y)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 40), flapRotationSpeed * Time.deltaTime);
        }
        _y = transform.position.y;

        if (_timer < 0.8f)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            _run = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        logic.gameOver();
        isAlive = false;
    }
}
