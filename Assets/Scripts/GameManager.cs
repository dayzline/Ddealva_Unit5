using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.0f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score = 0;
    public bool gameActive = true;
    public Button restartButton;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    public void StartGame(float difficulty)
    {
        gameActive = true;
        score = 0;
        spawnRate /= difficulty;
        Debug.Log("Difficulty is" + difficulty);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
    
    public void GameOver()
    {
        gameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreDelta)
    {
        score += scoreDelta;
        if (score < 0)
            score = 0;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while(gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
}
