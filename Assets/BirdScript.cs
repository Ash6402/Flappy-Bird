using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public LogicScript logic;
    public float flapStrength;
    public bool isAlive = true;

    private AudioSource flapAudio;
    // Start is called before the first frame update
    void Start()
    {
        flapAudio = GetComponent<AudioSource>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            rigidbody.velocity = Vector2.up * flapStrength;
            flapAudio.Play();
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        logic.gameOver();
        isAlive = false;
    }
}
