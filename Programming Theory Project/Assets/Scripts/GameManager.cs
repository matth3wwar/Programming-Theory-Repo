using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject inGameHud;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject gameOverScreen;

    [SerializeField] GameObject platform;
    [SerializeField] GameObject player;
    [SerializeField] GameObject startingPlayer;
    PlayerController playerController;
    Rigidbody2D playerRb;
    Vector3 playerStartPos;
    Vector3 platformStartPos;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI gameOverHighScoreText;

    public int lives;
    public int score;
    public int highScore;

    public bool isGameActive;
    public bool isGameOver;

    void Start()
    {
        MainManager.Instance.LoadData();
        playerController = player.GetComponent<PlayerController>();
        playerRb = player.GetComponent<Rigidbody2D>();
        playerStartPos = player.transform.position;
        platformStartPos = platform.transform.position;

        StartGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive && !isGameOver)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !isGameActive && !isGameOver)
        {
            ResumeGame();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "score :" + score;
    }

    public void DamagePlayer(int damage)
    {
        if (lives > 0)
        {
            lives -= damage;
            livesText.text = "Lives :" + lives;
        }
        else
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        if (!isGameOver)
        {
            ResumeGame();
            GameOver();
        }

        Cursor.lockState = CursorLockMode.Locked;
        isGameOver = false;
        isGameActive = true;
        gameOverScreen.SetActive(false);
        inGameHud.SetActive(true);
        player.SetActive(true);
        platform.SetActive(true);
        startingPlayer.SetActive(true);
        lives = 10;
        DamagePlayer(0);
        score = 0;
        AddScore(0);
        player.transform.position = playerStartPos;
        platform.transform.position = platformStartPos;
        playerRb.AddForce(new Vector2(-0.5f, -1) * playerController.initialSpeed, ForceMode2D.Impulse);

        playerController.platformColors[6].SetActive(false);
        playerController.colorToDelete = 6;
        playerController.UpdatePlatformColor();
    }

    void PauseGame()
    {
        isGameActive = false;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isGameOver = true;
        gameOverScreen.SetActive(true);
        inGameHud.SetActive(false);
        playerController.playerColors[playerController.colorToDelete].SetActive(false);
        player.SetActive(false);
        platform.SetActive(false);
        if (score > highScore)
        {
            highScore = score;
            MainManager.Instance.UpdateHighScore(highScore);
            highScoreText.text = ("high score: " + highScore);
        }
        gameOverHighScoreText.text = ("high score: " + highScore);
        gameOverScoreText.text = ("score: " + score);
    }

    public void Quit()
    {
        MainManager.Instance.LoadMainMenu();
    }
}
