using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Powerups"))
        {
            Destroy(other.gameObject);
            //sumar vida
            playerData.Healing(other.gameObject.GetComponent<Shine>().HealPoints);

            gameManager.Score++;
            Debug.Log(gameManager.Score);
        }

        if (other.gameObject.CompareTag("Munitions"))
        {
            Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
            playerData.Damage(other.gameObject.GetComponent<munition>().DamagePoints);
            Destroy(other.gameObject);
            if (playerData.HP <= 0)
            {
                Debug.Log("GAME OVER");
            }
            gameManager.Score--;
            Debug.Log(gameManager.Score);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {

    }
}