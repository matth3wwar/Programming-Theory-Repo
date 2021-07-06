using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] playerColors;
    [SerializeField] GameObject platform;
    [SerializeField] GameObject[] platformColors;
    [SerializeField] GameObject topLine;
    [SerializeField] GameObject botLine;
    Rigidbody2D playerRb;

    float initialSpeed = 5.0f;
    float lineSpeed = 0.5f;
    float platformSpeed = 0.1f;
    float lineBound = 15.2f;
    float platformBound = 6;
    int colorIndex;
    int colorToDelete = 6;

    Vector3 topStartPos;
    Vector3 botStartPos;

    string playerColor;
    string platformColor;

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        playerRb.AddForce(new Vector2(-0.5f, -1) * initialSpeed, ForceMode2D.Impulse);

        topStartPos = topLine.transform.position;
        botStartPos = botLine.transform.position;

        colorToDelete = 6;
        UpdatePlatformColor();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLine();
        MovePlatform();
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

    void MoveLine()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        topLine.transform.Translate(Vector2.right * -horizontalInput * lineSpeed);
        botLine.transform.Translate(Vector2.right * horizontalInput * lineSpeed);

        
        if (botLine.transform.position.x >= lineBound || botLine.transform.position.x <= -lineBound)
        {
            topLine.transform.position = topStartPos;
            botLine.transform.position = botStartPos;
        }
    }

    void MovePlatform()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        platform.transform.Translate(Vector2.right * horizontalInput * platformSpeed);

        if (platform.transform.position.x >= platformBound)
        {
            platform.transform.position = new Vector3(platformBound, platform.transform.position.y, platform.transform.position.z);
        }
        if (platform.transform.position.x <= -platformBound)
        {
            platform.transform.position = new Vector3(-platformBound, platform.transform.position.y, platform.transform.position.z);
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
