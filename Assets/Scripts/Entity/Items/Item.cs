using UnityEngine;
using System.Collections;

public abstract class Item : Entity
{
    [Range(0, 4)]
    public float _moveSpeed;

    protected override void FixedUpdate()
    {
        MoveUp(_moveSpeed);

        // check collision
        if (CollidePlayer())
            OnCollision();
    }

    protected abstract void OnCollision();
}
