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

    bool hasSpinned; // can be used to start game as well
    bool wasSpinningLeft;
    int rotateSpeed = 5;
    float rotateBufferSpeed = 0.1f;

	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	void FixedUpdate ()
	{
		float x_move = Input.GetAxis ("Horizontal");
			
		Vector2 move = new Vector2 (x_move, 0);

        // speed buffer
        /*
        if (x_move == 0 && (int)body.velocity.x != 0)
        {
            float speedBuffer = Mathf.Lerp(body.velocity.x,0,0.1f);
            move.x = speedBuffer;
            body.velocity = move * speed;
        }
        else
            body.velocity = move * speed;
        */

        body.velocity = move * speed;

        body.position = new Vector2 (Mathf.Clamp (body.position.x, bounds.xMin, bounds.xMax), body.position.y);

        //anim.SetFloat ("Speed", move.x);

        Rotate(x_move);

		//Debug.Log (Mathf.Clamp (body.velocity.x, -1, 1) * 0.8f);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Pearl") {
			other.gameObject.SetActive (false);
			ScoreManager.instance.UpdatePearls ();
		}
	}

    // ** Attention:
    // z degree is reversed in unity
    // z > 0, turn left

    void Rotate(float vel)
    {
        float deg = 0;

        if (vel == 0)
        {
            float zRotation = transform.rotation.eulerAngles.z;

            //if(!hasSpinned || zRotation % 360 ==0)
            //   return;


            if (!hasSpinned || (int)zRotation == 0 || (int)zRotation == 360)
                return;

            float buffer=0;
            float targetDeg = 0;

            if (wasSpinningLeft)
            {
                targetDeg = 360; // ** reversed. normal sense would be 0
                buffer = Mathf.Lerp(zRotation, targetDeg, rotateBufferSpeed);

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, buffer));
            }

            else{
                targetDeg = 0; // ** reversed. normal sense would be 360

                buffer = Mathf.Lerp(zRotation, targetDeg, rotateBufferSpeed);

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, buffer));
            }
        }
            
        else if (vel > 0){
            deg = -1 * rotateSpeed;
            if(!hasSpinned)
                hasSpinned = true;
            wasSpinningLeft = false;
        }
        else if (vel < 0){
            deg = 1 * rotateSpeed; 
            if(!hasSpinned)
                hasSpinned = true;
             wasSpinningLeft = true;
        }

        transform.Rotate(Vector3.forward,deg);
    }
}
