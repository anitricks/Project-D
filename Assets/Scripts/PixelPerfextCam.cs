using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class PixelPerfextCam : MonoBehaviour
{
    public int pixelPerUnit = 100;

    public Camera _cam { get; private set; }

    private float camRadio;
    public float camWidth { get; private set; }
    public float camHeight { get; private set; }
    public float camHalfWidth { get; private set; }
    public float camHalfHeight { get; private set; }

    void Awake()
    {
        _cam = GetComponent<Camera>();

        _cam.orthographicSize = Screen.height / pixelPerUnit / 2f;

        camRadio = _cam.aspect;
        camHeight = _cam.orthographicSize * 2;
        camWidth = camHeight * camRadio;

        camHalfWidth = camWidth / 2;
        camHalfHeight = camHeight / 2;
    }

}
