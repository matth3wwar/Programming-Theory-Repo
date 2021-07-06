using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] playerColors;
    [SerializeField] GameObject[] platformColors;
    Rigidbody2D playerRb;

    float initialSpeed = 5.0f;
    int colorIndex;
    int colorToDelete = 6;

    string playerColor;
    string platformColor;

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();

        StartGame();
    }


    // All methods bellow make use of abstraction for using them easily in start and collision methods

    void StartGame()
    {
        playerRb.AddForce(new Vector2(-0.5f, -1) * initialSpeed, ForceMode2D.Impulse);

        colorToDelete = 6;
        UpdatePlatformColor();
    }

    void UpdatePlayerColor()
    {
        playerColors[colorToDelete].SetActive(false);
        
        playerColor = platformColor;
        colorToDelete = colorIndex;

        playerColors[colorIndex].SetActive(true);
    }

    void UpdatePlatformColor()
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
        if (!color.gameObject.CompareTag(playerColor))
        {
            Debug.Log("Game Over");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Wall"))
        {
            UpdatePlayerColor();
            UpdatePlatformColor();
        }
    }
}
