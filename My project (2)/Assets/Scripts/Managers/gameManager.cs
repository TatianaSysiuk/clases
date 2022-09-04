using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private static int score;

    public static int Score { get => score; set => score = value; }


public static gameManager instance;

private void Awake() {
    if(instance == null){

        instance = this;
    }
    else{
        Destroy (gameObject);
    }
}





}
