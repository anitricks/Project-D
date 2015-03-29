using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour
{
    public static GM _instance { get; private set; }
    // other managers here

    public Starfish _player { get; private set; }

    void Awake()
    {
        _instance = this;

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Starfish>();
    }

    void OnLevelWasLoaded(int level)
    {

    }


    void InitGame()
    {

    }

}
