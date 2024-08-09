using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CapsuleScript : MonoBehaviour
{
    Rigidbody2D _body;
    CapsuleCollider2D _capsuleCollider;


    private GameObject _player;
    
    [SerializeField] private float _rangeOfAction = 10f;
    private bool isInRange;

    [SerializeField] private float _forceMultiplier = 5f;
    public Vector2 CapsulePostion { get; private set; }

    private Vector2 _fromPlayer;


    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
        _player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        CapsulePostion = _body.position;
        if (GameManager.IsForceFieldActive)
        {
            CheckDistanceFromPlayer();
            
        }

    }

    private void FixedUpdate()
    {
        if (GameManager.IsForceFieldActive && isInRange)
        {
            MoveAwayFromPlayer();
        }
    }

    private void CheckDistanceFromPlayer()
    {
        
        var _playerPos = _player.GetComponent<Rigidbody2D>().position;
        _fromPlayer = new Vector2(CapsulePostion.x - _playerPos.x,CapsulePostion.y - _playerPos.y);
        if (_fromPlayer.magnitude <= _rangeOfAction) { isInRange = true; }
        else { isInRange = false; }
    }

    private void MoveAwayFromPlayer()
    {
        Vector2 _capsuleVelocity = _fromPlayer.normalized * _forceMultiplier;

        _body.AddForce(_capsuleVelocity);
    
    }

    
}
