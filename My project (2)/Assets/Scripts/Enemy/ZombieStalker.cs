using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStalker : Zombie
{
    [SerializeField] Transform playerTransform;

    public Transform PlayerTransform { get => playerTransform; }

    protected override void Move()
    {
        
        LookPlayer();
        
        Vector3 direction = (PlayerTransform.position - transform.position);
        
        if (direction.magnitude > 1f)
        {
            
            transform.position += direction.normalized * zombieData.speed * Time.deltaTime;
        }
    }

    protected void LookPlayer()
    {
        
        Quaternion newRotation = Quaternion.LookRotation(PlayerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }
}