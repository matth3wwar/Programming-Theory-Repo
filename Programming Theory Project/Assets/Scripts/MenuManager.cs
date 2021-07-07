using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] mainMenuScreens;
    [SerializeField] TextMeshProUGUI[] highScoreNames;
    [SerializeField] TextMeshProUGUI[] highScores;
    [SerializeField] TMP_InputField nameSpace;

    int previousScreen = 0;

    void Start()
    {
        MainManager.Instance.LoadData();
        nameSpace.text = MainManager.Instance.localName;
    }

    public void UpdateLocalName()
    {
        MainManager.Instance.localName = nameSpace.text;
        MainManager.Instance.SaveData();
    }

    public void StartGame()
    {
        MainManager.Instance.SaveData();
        MainManager.Instance.StartGame();
    }

    public void LoadMainMenuScreen(int index)
    {
        mainMenuScreens[previousScreen].SetActive(false);
        mainMenuScreens[index].SetActive(true);
        previousScreen = index;

        if (index == 2)
        {
            UpdateHighScoreTable();
        }
    }

    void UpdateHighScoreTable()
    {
        MainManager.Instance.LoadData();
        highScoreNames[0].text = MainManager.Instance.highScoreName1;
        highScoreNames[1].text = MainManager.Instance.highScoreName2;
        highScoreNames[2].text = MainManager.Instance.highScoreName3;
        highScoreNames[3].text = MainManager.Instance.highScoreName4;
        highScoreNames[4].text = MainManager.Instance.highScoreName5;

        highScores[0].text = ("" + MainManager.Instance.highScore1);
        highScores[1].text = ("" + MainManager.Instance.highScore2);
        highScores[2].text = ("" + MainManager.Instance.highScore3);
        highScores[3].text = ("" + MainManager.Instance.highScore4);
        highScores[4].text = ("" + MainManager.Instance.highScore5);
    }

    public void ResetHighScores()
    {
        MainManager.Instance.highScoreName1 = null;
        MainManager.Instance.highScoreName2 = null;
        MainManager.Instance.highScoreName3 = null;
        MainManager.Instance.highScoreName4 = null;
        MainManager.Instance.highScoreName5 = null;

        MainManager.Instance.highScore1 = 0;
        MainManager.Instance.highScore2 = 0;
        MainManager.Instance.highScore3 = 0;
        MainManager.Instance.highScore4 = 0;
        MainManager.Instance.highScore5 = 0;

        MainManager.Instance.SaveData();
    }
}
