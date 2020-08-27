using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Variables that controler spawning waves
    [Header("Wave Settings")]
    public GameObject hazard;   // What we are spawning?
    public Vector2 spawnValue;  // Where are we spawning?
    public int hazardCount;     // How many hazards are we spawning per wave?

    [Header("Wave Timing Settings")]
    public float startWait;     // How long until the first wave start?
    public float spawnWait;     // How long between each hazard in a wave?
    public float waveWait;      // How long between each wave of hazards?

    [Header("UI Objects")]
    public Text scoreText;
    public GameObject gameOverTextObj;
    public GameObject restartTextObj;

    private int score = 0;
    private bool gameover = false;
    private bool restart = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we need to restart
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                // Restart our game.
                // The old way. Don't use this.
                /// Application.LoadLevel
                // The new way. Use this!
                SceneManager.LoadScene("Level 1");
            }
        }
    }

    // Coroutine to spawn waves of hazards
    IEnumerator SpawnWaves()
    {
        // Initial delay before the first wave
        yield return new WaitForSeconds(startWait);

        // Start spawning the wave
        while(true)
        {
            // Spawn wave
            for (int i = 0; i < hazardCount; i++)
            {
                // Spawn a single hazard
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));

                Instantiate(hazard, spawnPosition, Quaternion.identity); // Gimbal Lock (re: Quaternions)
                // Wait. Then spawn the next hazard
                yield return new WaitForSeconds(spawnWait);
            }

            // Wait. Spawn the next wave
            yield return new WaitForSeconds(waveWait);

            // Check to see if the game is over
            if (gameover)
            {
                restart = true;
                restartTextObj.SetActive(true);
                break;
            }
        }
    }

    public void AddToScore(int scoreValueToAdd)
    {
        score += scoreValueToAdd;
        // Debug.Log("Score: " + score);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // What happens whe my game is over?
        gameover = true;
        gameOverTextObj.SetActive(true);
    }
}
