using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;

    private float spawnRate = 1.0f;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Start the function to randomly spawn assets
        isGameActive = true; //Game is active at START... DOH
        StartCoroutine(SpawnTarget());
        UpdateScore(0); //Just to be sure -- even though variable is instantiated at 0;
        

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
    public void Gameover()  //Display Game over text and stop creating objects.
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false; 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
