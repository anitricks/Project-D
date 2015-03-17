using UnityEngine;
using System.Collections;

public class BgMover : MonoBehaviour
{

	public float moveSpeed;
	public float tileSize;

	// Update is called once per frame
	void Update ()
	{
		float newPosition = Mathf.Repeat (Time.time * Constants.moveSpeed * -1, tileSize);
		transform.position = Vector3.down * newPosition;
	
	}
}
