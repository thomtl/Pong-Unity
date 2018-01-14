using UnityEngine;

public class BallDirectionChooser : MonoBehaviour {
    public float xStartVelocity;
    public float yStartVelocity;
    private Rigidbody2D rb;
	// Use this for initialization
	private void Start () {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning(transform.name + " Has no RigidBody2D.");
            return;
        }
        ChooseDirection();

	}
    public void ChooseDirection()
    {
        float randomValue = Random.Range(1, 3);
        if (randomValue == 1)
        {
            rb.AddForce(new Vector3(xStartVelocity, yStartVelocity, 0f));
        }
        else if (randomValue == 2)
        {
            rb.AddForce(new Vector3(-xStartVelocity, yStartVelocity, 0f));
        }
    }
	
}
