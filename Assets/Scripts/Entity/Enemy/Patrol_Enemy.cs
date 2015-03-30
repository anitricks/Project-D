using UnityEngine;
using System.Collections;

public class Patrol_Enemy : Enemy
{
    [Range(1, 4)]
    public float maxDistance; // TODO: set based on screen resolution

    private float initialX;

    protected override void Awake()
    {
        base.Awake();
        initialX = _trans.position.x;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        MoveLeftRight();
    }

    private void MoveLeftRight()
    {
        // TODO: Lerp 
        float x = Mathf.PingPong(Time.time, maxDistance);
        _trans.position = new Vector2(initialX + x, _trans.position.y);
    }

}
