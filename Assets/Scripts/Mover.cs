using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	
	Rigidbody2D body;

	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		body.velocity = new Vector2 (0, Constants.moveSpeed);

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Finish") {
			gameObject.SetActive (false);
		}
	}




}
