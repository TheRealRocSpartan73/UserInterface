using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>(); //Grab a reference to the unique button.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
