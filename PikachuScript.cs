using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikachuScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool pikachuIsAlive = true;
    private AudioSource gameOverSound;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        gameOverSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && pikachuIsAlive == true) {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
        if (transform.position.y <= -50) {
            death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        death();
    }
    
    public void death() {
        gameOverSound.Play();
        logic.gameOver();
        logic.alive = false;
        pikachuIsAlive = false;
    }
}
