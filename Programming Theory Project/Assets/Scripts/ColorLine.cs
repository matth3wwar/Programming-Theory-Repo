using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLine : MoveObject
{
    public GameObject line;
    public int moveDirection = 1;

    // Inheritance & Polymorphism

    void Start()
    {
        SetStartPos(line);
    }

    void Update()
    {
        SetBounds(line);
        Move(line, moveDirection);
    }

    public override void SetBounds(GameObject platform)
    {
        if (platform.transform.position.x >= lineBound || platform.transform.position.x <= -lineBound)
        {
            platform.transform.position = startPos;
        }
    }
}
