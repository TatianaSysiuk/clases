using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour
{
   
    [SerializeField]
    [Range(2, 10)]
    private int healPoints = 2;
    public int HealPoints { get { return healPoints; } }
}
