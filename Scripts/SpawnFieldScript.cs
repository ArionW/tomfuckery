using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFieldScript : MonoBehaviour
{
    public GameEvent OnFieldEntered;
    private BoxCollider2D _spawnBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        _spawnBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnFieldEntered.Raise();
    }
}
