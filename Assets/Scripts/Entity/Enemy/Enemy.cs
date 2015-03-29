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
        base.FixedUpdate();

        // movement
        MoveUp();

        // check collision
        if (CollidePlayer())
            SomethingHappens();
    }

    private void MoveUp()
    {
        _trans.Translate(0, _moveSpeed * Time.deltaTime, 0);
    }

    private bool CollidePlayer()
    {
        if (GM._instance == null || GM._instance._player == null)
            return false;

        return _bound.Intersects(GM._instance._player._bound);
    }

    private void SomethingHappens()
    {
        Debug.Log("the shit's going down BITCH!");
    }
}
