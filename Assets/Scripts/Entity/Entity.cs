using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{

    public Transform _trans { get; private set; }
    public SpriteRenderer _renderer { get; private set; }
    public Bounds _bound { get { if (_renderer)return _renderer.bounds; else return GetComponent<SpriteRenderer>().bounds; } private set { } }

    protected virtual void Awake()
    {
        _trans = GetComponent<Transform>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void FixedUpdate()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_bound.center, _bound.size);
    }
}
