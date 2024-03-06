using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    private LogicScript _logic;

    private AudioSource _incrementSound;
    // Start is called before the first frame update
    private void Start()
    {
        _incrementSound = GetComponent<AudioSource>();
        _logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 3) return;
        _incrementSound.Play();
        _logic.Increment();
    }
}
