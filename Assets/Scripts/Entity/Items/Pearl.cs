using UnityEngine;
using System.Collections;

public class Pearl : Item
{
    public int value;
    public float chance;

    protected override void Start()
    {
        base.Start();
        _moveSpeed = 1;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void OnCollision()
    {
        gameObject.SetActive(false);
    }

}

