using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pooler: MonoBehaviour
{
	public GameObject pearl;
	public float yStartPos;
	Boundary bounds;
	public List<GameObject> p_list;

	void Start ()
	{
		bounds = new Boundary ();
		p_list = createPool (10, pearl, 0);
		StartCoroutine ("SpawnPearls");
	}



	public static List<GameObject> createPool (int amount, GameObject obj, float offset)
	{
		List<GameObject> tempList = new List<GameObject> ();
		for (int i = 0; i < amount; i++) {
			GameObject temp = (GameObject)Instantiate (obj, obj.transform.position, Quaternion.identity);
			temp.transform.position = new Vector3 (temp.transform.position.x, i * offset, temp.transform.position.z);
			temp.name += temp.name + (i + 1).ToString ("00");
			temp.SetActive (false);
			tempList.Add (temp);
		}

		return tempList;

	}
	// Update is called once per frame
	void Update ()
	{

	
	}

	IEnumerator SpawnPearls ()
	{
		while (true) {
			yield return new WaitForSeconds (Random.Range (1, 3));
			for (int i = 0; i < p_list.Count; i++) {
				if (!p_list [i].activeInHierarchy) {
					p_list [i].transform.position = new Vector3 (Random.Range (-2.1f, 2.1f), -5.3f, p_list [i].transform.position.z);
					p_list [i].SetActive (true);
					break;
				}
			}
		}
	}
}
