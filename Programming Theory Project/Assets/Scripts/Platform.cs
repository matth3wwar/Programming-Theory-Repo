using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MoveObject
{
    public GameObject platform;

    // Inheritance & Polymorphism
    
    void Start()
    {
        FindGameManager();
    }

    void Update()
    {
        Move(platform);
        SetBounds(platform);
    }
}
