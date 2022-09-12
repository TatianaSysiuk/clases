using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour



{

    [SerializeField] private Text selectedText;
    public static HUDmanager instance;
    // Start is called before the first frame update


    private void Awake() {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedText(string newText){
        selectedText.text = newText;
    }
}
