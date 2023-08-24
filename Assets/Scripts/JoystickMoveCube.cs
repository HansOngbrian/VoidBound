using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMoveCube : MonoBehaviour
{
    public float Speed = 5;

    // Update is called once per frame
    void Update()
    {
        float horizontal = TwinSticks.Left.Horizontal;
        float vertical = TwinSticks.Left.Vertical;
        transform.Translate(horizontal * Speed * Time.deltaTime, vertical * Speed * Time.deltaTime, 0);
    }
}
