using UnityEngine;
using System.Collections;

public class Starfish : Entity
{

    private float moveDir;
    private float screenBound;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        screenBound = GM._instance._mainCam.camHalfWidth - _bound.size.x / 2;

        _moveSpeed = 4;
    }

    protected override void FixedUpdate()
    {
        //base.FixedUpdate();

        float x = Input.GetAxis("Horizontal");
        float moveDis = x * _moveSpeed * Time.deltaTime;

        // predict collision
        if (Mathf.Abs(_trans.position.x + moveDis) < screenBound)
            Move(moveDis);
    }

    void Move(float dis)
    {
        _trans.Translate(dis, 0, 0);
    }

    public void SetSprite(Sprite sprite)
    {
        _renderer.sprite = sprite;
    }

    protected override void OnCollision()
    {
        // do no thing
    }
}
