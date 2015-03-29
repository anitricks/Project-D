using UnityEngine;
using System.Collections;

public abstract class Enemy : Entity
{
    [Range(0, 4)]
    public float _moveSpeed;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FixedUpdate()
    {
        //base.FixedUpdate();

        // movement
        MoveUp(_moveSpeed);

        // check collision
        if (CollidePlayer())
            SomethingHappens();
    }



    private void SomethingHappens()
    {
        Debug.Log("the shit's going down BITCH!");
    }
}
