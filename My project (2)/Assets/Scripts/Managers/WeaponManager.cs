using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    //AGRUPAMIENTO FIJO
    [SerializeField] GameObject[] weapons;

    [SerializeField] Transform playerHand;


    //2 TDA LISTA
    [SerializeField] List<GameObject> weaponList;
    public List<GameObject> WeaponList { get => weaponList; set => weaponList = value; }

    // 3 TDA COLA

     private Queue weaponQueue;
    public Queue WeaponQueue { get => weaponQueue; set => weaponQueue = value; }

// 4 stack

private Stack weaponStack;
public Stack WeaponStack {get => weaponStack; set => weaponStack = value;}


// 5 TDA diccionario
private Dictionary<string, GameObject> weaponDirectory;
public Dictionary<string,GameObject> WeaponDirectory {get => weaponDirectory; set => weaponDirectory = value;}

    void Start()
    {
        /* weapons[0].SetActive(true);
         weapons[0].transform.parent = playerHand;
         weapons[0].transform.localPosition = Vector3.zero; */
        //  DiseableAllWeapons();
        weaponList = new List<GameObject>();
        weaponQueue = new Queue();
        weaponStack = new Stack();
        weaponDirectory = new Dictionary<string, GameObject> ();
    }

    void DiseableAllWeapons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }

    void EnableAllWeapon()
    {

        foreach (GameObject weapon in weaponList)
        {
            weapon.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) EnableAllWeapon();
        //input queq

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (weaponQueue.Count > 0)
            {
                GameObject weapon = weaponQueue.Dequeue() as GameObject;
                weapon.SetActive(true);
            }
        }

        //INPUT STACK

         if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weaponStack.Count > 0)
            {
                GameObject weapon = weaponStack.Pop() as GameObject;
                weapon.SetActive(true);
            }
        }

        //diccionario

        if (Input.GetKeyDown(KeyCode.Alpha3)) weaponDirectory["WeaponA"].SetActive(true);
        if (Input.GetKeyDown(KeyCode.Alpha4)) weaponDirectory["WeaponB"].SetActive(true);
        if (Input.GetKeyDown(KeyCode.Alpha5)) weaponDirectory["WeaponD"].SetActive(true);
        if (Input.GetKeyDown(KeyCode.Alpha6)) weaponDirectory["WeaponC"].SetActive(true);
    }
}
