using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    GameManager _gameManager;
    Camera _mainCamera;

    public Vector2 PlayerPosition { get; private set; }
    Rigidbody2D _playerBody;
    BoxCollider2D _playerCollider;

    [SerializeField] float _playerSpeed = 5f;
    [SerializeField] float _rotationSpeed = 3f;

       
    Vector2 _moveDirection;
    Vector2 _playerVelocity;
    Vector2 _playerRotation;
    float _rotationVelocity;
    

    [SerializeField] GameObject _playerPoint;

    // Start is called before the first frame update
    void Start()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;


    }

    // Update is called once per frame
    void Update()
    {
        MoveCheck();



    }

    private void FixedUpdate()
    {
        MovePlayer();


    }


    void MoveCheck()
    {
        _moveDirection = Vector2.zero;
        _playerRotation = new Vector2(transform.up.x,transform.up.y);

        if (Input.GetKey(KeyCode.W)) { _moveDirection += Vector2.up; }
        if (Input.GetKey(KeyCode.S)) { _moveDirection += Vector2.down; }
        if (Input.GetKey(KeyCode.E)) { _moveDirection += Vector2.right; }
        if (Input.GetKey(KeyCode.Q)) { _moveDirection += Vector2.left; }


        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) { _rotationVelocity = 0; }
        else
        {
            if (Input.GetKey(KeyCode.A)) { _rotationVelocity = 1; }
            else if (Input.GetKey(KeyCode.D)) { _rotationVelocity = -1; }
            else { _rotationVelocity = 0; }
        }
        
        _moveDirection = _moveDirection.normalized ;
        _moveDirection = Quaternion.AngleAxis(_playerBody.rotation, Vector3.forward) * _moveDirection;

        PlayerPosition = _playerBody.position;
       

    }

    void MovePlayer()
    {
       
        _playerBody.AddForce(_moveDirection * _playerSpeed);
        _playerBody.AddTorque(_rotationVelocity * _rotationSpeed);
        
    
    
    
    }
}
