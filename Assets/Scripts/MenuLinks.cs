using UnityEngine;
using System.Collections;

public class MenuLinks : MonoBehaviour
{
	bool already = false;
	Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	public void showHelp ()
	{
		if (!already) {
			anim.SetTrigger ("Help");
			already = true;
		} else {
			anim.SetTrigger ("Help-Rev");
			already = false;
		}
	}
}
