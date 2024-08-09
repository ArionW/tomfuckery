using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public bool GameOver = false;

    public static bool IsForceFieldActive;
    public GameEvent OnForcefieldActivate;

    private void Start()
    {
        IsForceFieldActive = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            OnForcefieldActivate.Raise();
            IsForceFieldActive = !IsForceFieldActive;
            Debug.Log("U pressed! Forcefield: " + IsForceFieldActive.ToString());
        }
    }

}
