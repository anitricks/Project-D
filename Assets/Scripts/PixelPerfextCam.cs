using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class PixelPerfextCam : MonoBehaviour
{
    public int pixelPerUnit = 100;

    private Camera _cam;

    void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    void Start()
    {
        _cam.orthographicSize = Screen.height / pixelPerUnit / 2f;
    }

}
