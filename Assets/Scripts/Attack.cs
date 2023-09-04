using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    void Update()
    {
        Vector3 aimDir = new Vector3(TwinSticks.Left.Horizontal, TwinSticks.Left.Vertical, 0);
        if(aimDir.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(transform.forward, -aimDir);
        }
    }
}
