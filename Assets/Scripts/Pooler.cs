using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Constants
{
	public static float moveSpeed = 6;
}

public class Boundary
{
	public static float xMin = -2.1f, xMax = 2.1f, startPos = -5.4f;
}

public class Pooler: MonoBehaviour
{
	public List<GameObject> objPoolList;
	public Vector2 timeVals;
	public int amount;
	public bool rand;
	List<GameObject> p_list;

	void Start ()
	{
		p_list = createPool (amount, objPoolList);
		StartCoroutine ("SpawnPool");
	}

	public List<GameObject> createPool (int amount, List<GameObject> objList)
	{
		List<GameObject> tempList = new List<GameObject> ();
		for (int i = 0; i < amount; i++) {
			GameObject obj = GetObj (objList, rand);
			GameObject temp = (GameObject)Instantiate (obj, obj.transform.position, Quaternion.identity);
			//temp.transform.position = new Vector3 (temp.transform.position.x, i * offset, temp.transform.position.z);
			temp.name += (i + 1).ToString ("00");
			temp.SetActive (false);
			tempList.Add (temp);
		}
		
		return tempList;
		
	}
	GameObject GetObj (List<GameObject> randList, bool random)
	{
		if (randList.Count == 1) {
			return randList [0];
		} else {
			if (random) {
				int randInt = Random.Range (0, randList.Count);
				return randList [randInt];
			} else {
				int num = Random.Range (0, 100);
				int len = randList.Count;
				if (num <= 75) {
					return randList [0];
				} else if (num > 75 && num <= 90) {
					return randList [0];
				} else if (num > 90 && num < 98) {
					return randList [2];
				} else if (num >= 98 && num <= 99) {
					return randList [3];
				} else {
					return randList [0];
				}
			}
		}

	}

	IEnumerator SpawnPool ()
	{
		while (true) {
			yield return new WaitForSeconds (Random.Range (timeVals.x, timeVals.y));
			for (int i = 0; i < p_list.Count; i++) {
				if (!p_list [i].activeInHierarchy) {
					p_list [i].transform.position = new Vector3 (Random.Range (Boundary.xMin, Boundary.xMax), Boundary.startPos, p_list [i].transform.position.z);
					p_list [i].SetActive (true);
					break;
				}
			}
		}
	}
}

