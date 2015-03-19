using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance;
	public Text p_text, d_text;
	int count;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this);
		}

	}
	// Use this for initialization
	void Start ()
	{
		count = 0;
		p_text.text = count.ToString ("0");
	}
	
	// Update is called once per frame
	void Update ()
	{
		d_text.text = Mathf.Abs (Time.time).ToString ("0,0") + "m";
	}

	public void UpdatePearls (int amt)
	{
		count += amt;
		p_text.text = count.ToString ("00");
	}
}
