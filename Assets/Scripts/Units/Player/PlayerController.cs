using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerSpawn playerSpawn;
    
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
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Repeat checkpoint");
            StartCoroutine(WaitToSpawn());
        }
    }

    private IEnumerator WaitToSpawn()
    {
        playerMovement.SetSpeedRotation(0f,0f);
        playerSpawn.SetConstraints();
        yield return new WaitForSeconds(1f);
        playerSpawn.SpawnPlayer();
        
        yield return new WaitForSeconds(1f);
        playerSpawn.ResetConstraints();
        playerMovement.SetSpeedRotation(20f,120f);
    }
}
