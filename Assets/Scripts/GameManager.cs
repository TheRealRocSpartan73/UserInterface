using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;

    private float spawnRate = 1.5f;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
       
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Spawns random objects
    IEnumerator SpawnTarget()
    {
        while (isGameActive == true)
        {
            yield return new WaitForSeconds(spawnRate); //Wait then spawn
            int index = Random.Range(0, targets.Count); //Select Random object from list
            Instantiate(targets[index]); //Finally create the object  -object will bounce based on the logic within Target.cs
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    //GAME OVER MAN
    public void Gameover()  //Display Game over text and stop creating objects. Give option to restart
    {
        
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame() //Once Restart Button has been clicked, reload the scene.
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        //Start the function to randomly spawn assets
        isGameActive = true; //Game is active at START... DOH
        spawnRate /= difficulty;  //Divide spawn rate by button difficulty so 1 second, 0.5 seconds or 0.3ish seconds for each spawn.
        UpdateScore(0); //Just to be sure -- even though variable is instantiated at 0;
        StartCoroutine(SpawnTarget());

        titleScreen.gameObject.SetActive(false); //Game has started remove title screen
        
    }

}
