using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerSpawn playerSpawn;
    private Animator _playerAnimator;
    
    
    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveAction;
    
    
    private Vector2 _moveInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
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
        if (_moveInput.x != 0 || _moveInput.y != 0)
        {
            _playerAnimator.SetBool("Move", true);
        }
        else
        {
            _playerAnimator.SetBool("Move", false);
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("ObstacleCut"))
        {
            if(other.CompareTag("Obstacle"))  _playerAnimator.SetBool("IsSmashed", true);
            else if(other.CompareTag("ObstacleCut"))  _playerAnimator.SetBool("IsCut", true);
            Debug.Log("Repeat checkpoint");
            StartCoroutine(WaitToSpawn());
        }
    }

    private IEnumerator WaitToSpawn()
    {
        playerMovement.SetSpeedRotation(0f,0f);
        playerSpawn.SetConstraints();
        yield return new WaitForSeconds(1f);
        _playerAnimator.SetBool("IsSmashed", false);
        _playerAnimator.SetBool("IsCut", false);
        _playerAnimator.SetBool("IsSpawing", true);
        playerSpawn.SpawnPlayer();
        
        yield return new WaitForSeconds(1f);
        _playerAnimator.SetBool("IsSpawing", false);
        playerSpawn.ResetConstraints();
        playerMovement.SetSpeedRotation(20f,120f);
    }
}
