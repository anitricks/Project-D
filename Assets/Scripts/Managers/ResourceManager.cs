using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{
    // maybe a dictionary
    public GameObject[] playerPrefabs;
    public GameObject[] peralPrefabs;

    void Awake()
    {

    }

    public void LoadPlayers()
    {
        playerPrefabs = Resources.LoadAll<GameObject>(Constant.STARTFISH_PREFABS);

        //Resources.Load<GameObject>(ConstantManager.PREFAB_STARFISH_0);
    }

    public void LoadPeral()
    {
        peralPrefabs = Resources.LoadAll<GameObject>(Constant.PERAL_PREFABS);
    }

}
