using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerMovement playerMovement;
    
    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveAction;
    
    
    private Vector2 _moveInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _moveInput =  moveAction.action.ReadValue<Vector2>();
        playerMovement.Movement(_moveInput.y);
        playerMovement.Rotation(_moveInput.x);
    }
}
