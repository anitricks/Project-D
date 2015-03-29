using UnityEngine;
using System.Collections;

public class Starfish : Entity
{
    public float moveSpeed = 2;
    private byte inBoundHelper = 1;
    private float moveDir;
    private float screenBound;


    protected override void Awake()
    {
        base.Awake();

    }

    void Start()
    {
        screenBound = GM._instance._mainCam.camHalfWidth - _bound.size.x / 2;

    }

    protected override void FixedUpdate()
    {
        //base.FixedUpdate();

        float x = Input.GetAxis("Horizontal");

        float moveDis = x * moveSpeed * Time.deltaTime;

        // predict collision
        if (Mathf.Abs(_trans.position.x + moveDis) < screenBound)
            Move(moveDis);

        // KeepInBound();
    }

    void Move(float dis)
    {
        _trans.Translate(dis, 0, 0);

    }

    private void KeepInBound()
    {
        if (!GM._instance)
            return;

        if (GM._instance._mainCam.camHalfWidth - Mathf.Abs(_trans.position.x) <= _bound.size.x / 2)
            _trans.position = _trans.position;
        //inBoundHelper = 0;
        //else
        //inBoundHelper = 1;

    }
}
