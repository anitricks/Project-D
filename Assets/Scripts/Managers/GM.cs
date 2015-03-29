using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour
{

    public static GM _instance { get; private set; }
    // other managers here

    public Starfish _player { get; private set; }
    public PixelPerfextCam _mainCam { get; private set; }

    void Awake()
    {
        _instance = this;

        _mainCam = Camera.main.GetComponent<PixelPerfextCam>();
        //_mainCam = GameObject.FindGameObjectWithTag("Main Camera").GetComponent<PixelPerfextCam>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Starfish>();
    }

    void InitGame()
    {
        if (_player == null)
            Debug.Log("create player here");
    }

}
