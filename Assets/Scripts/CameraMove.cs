using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction Moveaction; 
    static public Vector3 face;
    [SerializeField] float speed = 1;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        Moveaction = playerInput.actions.FindAction("Movement");
    }



    private void Update()
    {
        Move();
    }



    private void Move()
    {
        Vector2 direction = Moveaction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x,direction.y,0)*Time.deltaTime*speed;
    }

}
