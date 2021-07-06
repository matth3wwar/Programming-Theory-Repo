using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.IO;

public class MainManager : MonoBehaviour
{
    // Encapsulation
    public static MainManager Instance { get; private set; }

    public bool circleGame;
    public bool lineGame;
    public bool easyMode;
    public bool normalMode;
    public bool hardMode;

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
}
