using System;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    
    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        
        _rb.position = spawnPoint.position;
        _rb.rotation = Quaternion.Euler(0f,90f,0f);
    }

    public void SetConstraints()
    {
        _rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    
    public void ResetConstraints()
    {
        _rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationZ;
    }
}
