using UnityEngine;
using System.Collections;

public class Pearl : Item
{

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

    }

    protected override void OnCollision()
    {
        gameObject.SetActive(false);
    }
}

