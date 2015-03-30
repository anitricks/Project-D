using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public int num;
	Rigidbody2D body;

	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		body.velocity = new Vector2 (0, num);

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Finish") {
			gameObject.SetActive (false);
		}

		if (gameObject.tag == "Pearl" && other.tag == "Enemy-A") {
			gameObject.SetActive (false);
		}
	}




}
