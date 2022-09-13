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
       /* if (Input.GetKeyDown(KeyCode.Q)) EnableAllWeapon();
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
        if (Input.GetKeyDown(KeyCode.Alpha6)) weaponDirectory["WeaponC"].SetActive(true);*/

        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipWeapon(weaponDirectory["WeaponA"]);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipWeapon(weaponDirectory["WeaponB"]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipWeapon(weaponDirectory["WeaponC"]);
        if (Input.GetKeyDown(KeyCode.Alpha4)) EquipWeapon(weaponDirectory["WeaponD"]);
    }

    //método para verificar si la cola está vacía.
    private bool IsQueueEmpty()
    {
        return weaponQueue.Count > 0;
    }

    //método para verificar si la pila está vacía.

    private bool IsStackEmpty()
    {
        return weaponStack.Count > 0;
    }


    //método que permite equipoar el arma al player
    private void EquipWeapon(GameObject weapon)
    {
        DetachWeapons ();
        weapon.SetActive (true);
        weapon.transform.parent = playerHand;
        weapon.transform.localPosition = Vector3.zero;
    }


//método para remparentar todos los hijos
    private void DetachWeapons()
    { //foreach para recorrer todos los hijos
        foreach(Transform child in playerHand)
        {
            child.parent = null;
            child.transform.position = new Vector3(Random.Range(0f,3f), 1f,Random.Range(0f,3f));
            child.gameObject.SetActive(true);
        }
    }



}
