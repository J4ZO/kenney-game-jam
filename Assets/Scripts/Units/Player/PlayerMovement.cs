using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    
    
    [Header("Isometric Settings")]
    [SerializeField] private float isometricAngle = 45f;
    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    public void Movement(float direction)
    {
        float angle = GetRotationAngle();
        _rb.AddRelativeForce(Vector3.forward * (direction  * moveSpeed));
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void Rotation(float rotation)
    {
        Quaternion newRot = Quaternion.Euler(0f, rotation * (rotationSpeed * Time.fixedDeltaTime),0f);
        _rb.MoveRotation(_rb.rotation * newRot );
    }

    private float GetRotationAngle()
    {
        Debug.Log("rotation" + transform.eulerAngles.normalized.y);
        return transform.eulerAngles.normalized.y;
    }
}
