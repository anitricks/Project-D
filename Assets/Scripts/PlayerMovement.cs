using UnityEngine;
using System.Collections;


public class Constants
{
	public static float moveSpeed = 8;
}
[System.Serializable]
public class Boundary
{
	public float xMin, xMax;

}
[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	public float speed;
	Rigidbody2D body;
	Animator anim;
	public Boundary bounds;

	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	void FixedUpdate ()
	{
		float x_move = Input.GetAxis ("Horizontal");
			
		Vector2 move = new Vector2 (x_move, 0);

		body.velocity = move * speed;

		body.position = new Vector2 (Mathf.Clamp (body.position.x, bounds.xMin, bounds.xMax), body.position.y);

		anim.SetFloat ("Speed", move.x);

		//Debug.Log (Mathf.Clamp (body.velocity.x, -1, 1) * 0.8f);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Pearl") {
			other.gameObject.SetActive (false);
			ScoreManager.instance.UpdatePearls ();
		}
	}

}
