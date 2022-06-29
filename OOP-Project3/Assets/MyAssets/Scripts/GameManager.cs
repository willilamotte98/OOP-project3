using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //interface

public class GameManager : MonoBehaviour{
    //UI
    [SerializeField] GameObject gameOverMenu;
    public int lives { get; set; }
    [SerializeField] TextMeshProUGUI livesText;
    private int score;
    [SerializeField] TextMeshProUGUI scoreText;

    //Spawn Manager
    [SerializeField] GameObject[] objectPrefabs;
    private float startDelay = 0.5f;
    private float spawnInterval = 1.0f;
    private float randomRangeZ = 3.5f;
    private float positionX = 10.0f;
    private float positionY = 0.5f;

    void Start(){
        UpdateLives(3);
        UpdateScore(0);
        InvokeRepeating("SpawnRandomObjects", startDelay, spawnInterval);
    }

    public void GameOver(){
        gameOverMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        livesText.text = "Lives : 0";
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void UpdateScore(int scoreToAdd){ //4 - Abstraction
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    public void UpdateLives(int livesToChange){ //4 - Abstraction
        lives += livesToChange;
        livesText.text = "Lives : " + lives;
    }
    void SpawnRandomObjects(){
        Vector3 spawnPos = new Vector3(positionX, positionY, Random.Range(-randomRangeZ, randomRangeZ));
        int objectIndex = Random.Range(0, objectPrefabs.Length);
        Instantiate(objectPrefabs[objectIndex], spawnPos, objectPrefabs[objectIndex].transform.rotation);
    }
}
