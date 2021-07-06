using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject easyRoulete;
    [SerializeField] GameObject normalRoulete;
    [SerializeField] GameObject hardRoulete;
    [SerializeField] GameObject botLine;
    [SerializeField] GameObject topLine;

    bool isGameActive;

    void Start()
    {
        if (MainManager.Instance.circleGame)
        {
            StartCircleGame();
        }
        else
        {
            StartLineGame();
        }
    }

    void EasyMode()
    {
        easyRoulete.SetActive(true);
    }

    void NormalMode()
    {
        normalRoulete.SetActive(true);
    }

    void HardMode()
    {
        hardRoulete.SetActive(true);
    }

    void StartCircleGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        if (MainManager.Instance.easyMode)
        {
            EasyMode();
        }
        else if (MainManager.Instance.normalMode)
        {
            NormalMode();
        }
        else if (MainManager.Instance.hardMode)
        {
            HardMode();
        }
    }

    void StartLineGame()
    {
        Cursor.lockState = CursorLockMode.Locked;

        topLine.SetActive(true);
        botLine.SetActive(true);
    }

    void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
