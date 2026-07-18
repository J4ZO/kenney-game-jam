using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float rotationSpeed;
    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    public void Movement(float direction)
    {
        float angle = GetRotationAngle();
        _rb.AddRelativeForce(Vector3.forward * (direction  * moveSpeed));
    }

    public void SetSpeedRotation(float speed, float rotation)
    {
        moveSpeed = speed;
        rotationSpeed = rotation;
    }

    public void Rotation(float rotation)
    {
        Quaternion newRot = Quaternion.Euler(0f, rotation * (rotationSpeed * Time.fixedDeltaTime),0f);
        _rb.MoveRotation(_rb.rotation * newRot );
    }

    private float GetRotationAngle()
    {
        return transform.eulerAngles.normalized.y;
    }
    

}
