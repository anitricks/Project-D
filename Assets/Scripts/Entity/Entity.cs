using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{

    public Transform _trans { get; private set; }

    public SpriteRenderer _renderer { get; private set; }
    public float _texWidth { get; private set; }
    public float _texHeight { get; private set; }

    public float _moveSpeed { get; protected set; }
    //public float _renderMaterial { get; private set; }

    public Bounds _bound { get { if (_renderer)return _renderer.bounds; else return GetComponent<SpriteRenderer>().bounds; } private set { } }

    protected float _outOfBoundPosY { get; private set; }

    protected virtual void Awake()
    {
        _trans = GetComponent<Transform>();
        _renderer = GetComponent<SpriteRenderer>();

        _texHeight = _renderer.bounds.size.y;
        _texWidth = _renderer.bounds.size.x;


    }

    protected virtual void Start()
    {
        _outOfBoundPosY = GM._instance._mainCam.camHalfHeight + _bound.size.y;
        Debug.Log(_outOfBoundPosY);
    }

    protected virtual void FixedUpdate()
    {
        OutOfBound();
    }

    protected abstract void OnCollision();


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_bound.center, _bound.size);
    }

    protected bool CollidePlayer()
    {
        if (GM._instance == null || GM._instance._player == null)
            return false;

        return _bound.Intersects(GM._instance._player._bound);
    }

    protected void MoveUp(float speed)
    {
        _trans.Translate(0, speed * Time.deltaTime, 0);
    }

    protected void OutOfBound()
    {
        if (_trans.position.y >= _outOfBoundPosY)
        {
            Debug.Log("out");

            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }



}
