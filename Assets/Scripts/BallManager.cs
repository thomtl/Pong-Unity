using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    private Vector2 velocity;
    private Rigidbody2D rb;
    [HideInInspector]public bool LastTouched;//true = player1 false = player2
    private BallDirectionChooser ballDirectionChooser;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballDirectionChooser = GetComponent<BallDirectionChooser>();
        if (rb == null)
        {
            Debug.LogError(transform.name + " has no RigidBody2D.");
        }
        if (ballDirectionChooser == null)
        {
            Debug.LogError(transform.name + " has no BallDirectionChooser.");
        }
    }
    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;
        ballDirectionChooser.ChooseDirection();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            velocity.x = rb.velocity.x;
            velocity.y = (rb.velocity.y / 2.0f) + (other.collider.attachedRigidbody.velocity.y / 3.0f);
            velocity.y = Random.Range(-5, 5);
            //transform.eulerAngles = new Vector3(0f, 0f, Random.Range(-60, 60));
            rb.velocity = velocity;
        }
        if (other.transform.name == "Player1")
        {
            LastTouched = true;
        }
        else if (other.transform.name == "Player2")
        {
            LastTouched = false;
        }
    }
}
