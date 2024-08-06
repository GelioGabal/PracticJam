using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class input : MonoBehaviour
{
    public static PlayerInputs inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputs();
        inputActions.Enable();
    }


    private void OnEnable()
    {
        
    }


    private void OnDisable()
    {
        
    }
}
