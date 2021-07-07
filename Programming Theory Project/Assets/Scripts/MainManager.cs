using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.IO;

public class MainManager : MonoBehaviour
{
    // Encapsulation
    public static MainManager Instance { get; private set; }

    public string highScoreName1;
    public string highScoreName2;
    public string highScoreName3;
    public string highScoreName4;
    public string highScoreName5;

    public int highScore1;
    public int highScore2;
    public int highScore3;
    public int highScore4;
    public int highScore5;

    public string localName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadData()
    {
        SaveData data = SaveSystem.LoadData();

        highScoreName1 = data.highScoreName1;
        highScoreName2 = data.highScoreName2;
        highScoreName3 = data.highScoreName3;
        highScoreName4 = data.highScoreName4;
        highScoreName5 = data.highScoreName5;

        highScore1 = data.highScore1;
        highScore2 = data.highScore2;
        highScore3 = data.highScore3;
        highScore4 = data.highScore4;
        highScore5 = data.highScore5;

        localName = data.localName;
    }

    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateHighScore(int newHighScore)
    {
        if (newHighScore > highScore1)
        {
            highScore5 = highScore4;
            highScore4 = highScore3;
            highScore3 = highScore2;
            highScore2 = highScore1;
            highScore1 = newHighScore;

            highScoreName5 = highScoreName4;
            highScoreName4 = highScoreName3;
            highScoreName3 = highScoreName2;
            highScoreName2 = highScoreName1;
            highScoreName1 = localName;
            
            SaveData();
        }
        else if (newHighScore > highScore2)
        {
            highScore5 = highScore4;
            highScore4 = highScore3;
            highScore3 = highScore2;
            highScore2 = newHighScore;

            highScoreName5 = highScoreName4;
            highScoreName4 = highScoreName3;
            highScoreName3 = highScoreName2;
            highScoreName2 = localName;
            
            SaveData();
        }
        else if (newHighScore > highScore3)
        {
            highScore5 = highScore4;
            highScore4 = highScore3;
            highScore3 = newHighScore;

            highScoreName5 = highScoreName4;
            highScoreName4 = highScoreName3;
            highScoreName3 = localName;
            
            SaveData();
        }
        else if (newHighScore > highScore4)
        {
            highScore5 = highScore4;
            highScore4 = newHighScore;

            highScoreName5 = highScoreName4;
            highScoreName4 = localName;
            
            SaveData();
        }
        else if (newHighScore > highScore5)
        {
            highScore5 = newHighScore;

            highScoreName5 = localName;
            SaveData();
        }
    }
}
