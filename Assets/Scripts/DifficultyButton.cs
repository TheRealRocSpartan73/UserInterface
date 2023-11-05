using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>(); //Grab a reference to the unique button.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(this.button.gameObject.name + " was clicked");
        gameManager.StartGame();
    }
}
