using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private Transform EndPoint;

    [SerializeField] private GameObject munition;

    [SerializeField]
    [Range(1f, 20f)]
    private float rayDistance = 10;

    bool canShoot = true;





    // Start is called before the first frame update
    void Start()
    {


    }



    // Update is called once per frame
    void Update()
    {
        CannonRaycast();
    }

    private void CannonRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(ShootPoint.position, ShootPoint.transform.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Player") && canShoot)
            {
                Debug.Log("COLLISION CON PLAYER");
                Instantiate(munition, ShootPoint.transform.position, munition.transform.rotation);
                canShoot = false;
                Invoke("delayShoot", 1f);
            }

        }
    }

    void delayShoot()
    {
        canShoot = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Vector3 direction = ShootPoint.transform.TransformDirection(Vector3.forward) * rayDistance;
        Gizmos.DrawRay(ShootPoint.position, direction);


    }


}
