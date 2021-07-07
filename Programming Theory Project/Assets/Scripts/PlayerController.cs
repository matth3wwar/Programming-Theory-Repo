using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] GameObject player;
    public GameObject[] playerColors;
    public GameObject[] platformColors;
    Rigidbody2D playerRb;

    public float initialSpeed = 5.0f;
    int colorIndex;
    public int colorToDelete = 6;
    Vector3 playerStartPos;

    string playerColor;
    string platformColor;

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void UpdatePlayerColor()
    {
        playerColors[colorToDelete].SetActive(false);
        
        playerColor = platformColor;
        colorToDelete = colorIndex;

        playerColors[colorIndex].SetActive(true);
    }

    public void UpdatePlatformColor()
    {
        platformColors[colorIndex].SetActive(false);
        colorIndex = Random.Range(0, 6);

        if (colorIndex == 0)
        {
            platformColor = "Red";
            platformColors[colorIndex].SetActive(true);
        }
        else if (colorIndex == 1)
        {
            platformColor = "Blue";
            platformColors[colorIndex].SetActive(true);
        }
        else if (colorIndex == 2)
        {
            platformColor = "Yellow";
            platformColors[colorIndex].SetActive(true);
        }
        else if (colorIndex == 3)
        {
            platformColor = "Green";
            platformColors[colorIndex].SetActive(true);
        }
        else if (colorIndex == 4)
        {
            platformColor = "Orange";
            platformColors[colorIndex].SetActive(true);
        }
        else if (colorIndex == 5)
        {
            platformColor = "Purple";
            platformColors[colorIndex].SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D color)
    {
        if (color.gameObject.CompareTag(playerColor))
        {
            gameManager.AddScore(5);
        }
        else
        {
            gameManager.DamagePlayer(1);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Wall") && col.gameObject.CompareTag("Ground"))
        {
            gameManager.DamagePlayer(gameManager.lives);
            gameManager.GameOver();
        }
        else if (!col.gameObject.CompareTag("Wall"))
        {
            UpdatePlayerColor();
            UpdatePlatformColor();
        }
    }
}
