﻿using UnityEngine;
using System.Collections;

public abstract class Item : Entity
{

    protected override void FixedUpdate()
    {
        MoveUp(_moveSpeed);

        // check collision
        if (CollidePlayer())
            OnCollision();
    }

}
