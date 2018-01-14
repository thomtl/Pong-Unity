using UnityEngine;

public class Player : MonoBehaviour {
    public KeyCode up;
    public KeyCode down;
    public float yMovement;
    private Rigidbody2D rb;

	private void Start () {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning(transform.name + " has no RigidBody returning.");
            return;
        }
	}
    public void ResetPlayerPos()
    {
        rb.MovePosition(new Vector3(transform.position.x, 0f, 0f));
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(up))
        {
            rb.MovePosition(transform.position + new Vector3(0f, yMovement));
        }
        if (Input.GetKey(down))
        {
            rb.MovePosition(transform.position + new Vector3(0f, -yMovement));
        }
    }

}
