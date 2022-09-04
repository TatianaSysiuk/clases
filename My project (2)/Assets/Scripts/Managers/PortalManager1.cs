using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager1 : MonoBehaviour
{

    [SerializeField] private Transform ShootPoint;
    [SerializeField] private Transform EndPoint;

    

    [SerializeField]
    [Range(1f, 20f)]
    private float rayDistance = 10;

    





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
        if (Physics.Raycast(ShootPoint.position, EndPoint.position, out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Player") )
            {
                Debug.Log("A PUNTO DE CRUZAR EL PORTAL");
                
            }

        }
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector3 direction = ShootPoint.transform.TransformDirection(Vector3.forward) * rayDistance;
        Gizmos.DrawLine(ShootPoint.position,EndPoint.position);


    }

}
