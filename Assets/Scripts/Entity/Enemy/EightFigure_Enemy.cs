using UnityEngine;
using System.Collections;

public class EightFigure_Enemy : Enemy
{
    private const float coefficient = 3;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        EightFigureMove();
    }

    void EightFigureMove()
    {
        float x = _trans.position.x;
        float y = _trans.position.y;

        // x^4 = a^2(x^2-y^2)
        x = Mathf.Sqrt(Mathf.Sqrt(coefficient * coefficient * (x * x - y * y)));

        y = Mathf.Sqrt(Mathf.Pow(x, 4) / Mathf.Pow(coefficient, 2) + Mathf.Pow(x, 2));

        _trans.position = new Vector2(x, y);
    }

    protected override void Start()
    {
        throw new System.NotImplementedException();
    }
}
