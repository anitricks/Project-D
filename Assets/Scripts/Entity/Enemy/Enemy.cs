using UnityEngine;
using System.Collections;

public abstract class Enemy : Entity
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        _moveSpeed = 2;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        // movement
        MoveUp(_moveSpeed);

        // check collision
        if (CollidePlayer())
            OnCollision();
    }

    protected override void OnCollision()
    {
        Debug.Log("end");

        //throw new System.NotImplementedException();

        // end game
    }

}
