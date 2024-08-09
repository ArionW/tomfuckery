using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CapsuleSpawner : MonoBehaviour
{
    public GameObject capsule;
    

    [SerializeField] private float _capsuleSpeed = 2f;
    private Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCapsule()
    { 
        Instantiate(capsule);
        
        Rigidbody2D _body = capsule.GetComponent<Rigidbody2D>();
        float rnd1 = Random.Range(-1, 1);
        float rnd2 = Random.Range(-1, 1);
        Vector2 move = new Vector2(rnd1, rnd2);
        _body.velocity = move * _capsuleSpeed;
    }
}
