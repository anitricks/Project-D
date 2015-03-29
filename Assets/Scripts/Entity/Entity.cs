using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{

    public Transform _trans { get; private set; }

    public SpriteRenderer _renderer { get; private set; }
    public float _texWidth { get; private set; }
    public float _texHeight { get; private set; }
    //public float _renderMaterial { get; private set; }

    public Bounds _bound { get { if (_renderer)return _renderer.bounds; else return GetComponent<SpriteRenderer>().bounds; } private set { } }

    protected virtual void Awake()
    {
        _trans = GetComponent<Transform>();
        _renderer = GetComponent<SpriteRenderer>();

        _texHeight = _renderer.bounds.size.y;
        _texWidth = _renderer.bounds.size.x;



    }

    protected virtual void FixedUpdate()
    {
        //KeepInBound();
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_bound.center, _bound.size);
    }
}
