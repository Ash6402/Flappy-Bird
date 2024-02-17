using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    private LogicScript logic;

    private AudioSource incrementSound;
    // Start is called before the first frame update
    void Start()
    {
        incrementSound = GetComponent<AudioSource>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            incrementSound.Play();
            logic.increment();
        }
    }
}
