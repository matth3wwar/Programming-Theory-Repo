using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public float lineSpeed = 0.5f;
    public float platformSpeed = 0.1f;
    public float lineBound = 15.2f;
    public float platformBound = 6;


    public Vector3 startPos;

    // Polymorphism

    protected void SetStartPos(GameObject line)
    {
        startPos = line.transform.position;
    }

    protected virtual void Move(GameObject line, int moveDirection)
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        line.transform.Translate(Vector2.right * horizontalInput * lineSpeed * moveDirection);
    }

    protected virtual void Move(GameObject platform)
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        platform.transform.Translate(Vector2.right * horizontalInput * platformSpeed);
    }

    public virtual void SetBounds(GameObject platform)
    {
        if (platform.transform.position.x >= platformBound)
        {
            platform.transform.position = new Vector3(platformBound, platform.transform.position.y, platform.transform.position.z);
        }
        if (platform.transform.position.x <= -platformBound)
        {
            platform.transform.position = new Vector3(-platformBound, platform.transform.position.y, platform.transform.position.z);
        }
    }
}
