using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;

    [SerializeField] WeaponManager weaponManager;

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
        if(other.gameObject.CompareTag("Weapons")){
//agregar el arma a la lista de armas
            other.gameObject.SetActive(false);
            weaponManager.WeaponList.Add(other.gameObject);
            //cola
            weaponManager.WeaponQueue.Enqueue(other.gameObject);
            Debug.Log("ELEMENTOS EN LA COLA"+ weaponManager.WeaponQueue.Count);
            //stack
             weaponManager.WeaponStack.Push(other.gameObject);
            Debug.Log("ELEMENTOS EN LA STACK"+ weaponManager.WeaponStack.Count);
            //diccionario
            weaponManager.WeaponDirectory.Add(other.gameObject.name,other.gameObject);
            Debug.Log(weaponManager.WeaponDirectory[other.gameObject.name]);
        }

    }

    private void OnTriggerExit(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {

    }
}