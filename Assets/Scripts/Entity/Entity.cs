using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{
    public Transform _trans { get; private set; }
    public Bounds _bound { get; private set; }
    public SpriteRenderer _renderer { get; private set; }

    protected virtual void Awake()
    {
        _trans = GetComponent<Transform>();
        _renderer = GetComponent<SpriteRenderer>();
        _bound = new Bounds(_trans.position, _renderer.bounds.size);

        

        Debug.Log(_bound.size.x + " " + _bound.size.y);
    }
    
    protected virtual void FixedUpdate()
    {
        UpdateBound();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_bound.center, _bound.size);
    }

    /// <summary>
    /// 
    /// </summary>
    private void UpdateBound()
    {
        _bound = new Bounds(_trans.position, _bound.size);
    }
}
