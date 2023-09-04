using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Required Features
    Attack Button
    Cooldown after each attack
    Will aim the closest enemy within line of sight
    mark closest enemy
    Summon bullet 
    attack animation

Editable in editor
    Attack damage
    Attack CD
*/
public class PlayerAttack : MonoBehaviour
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
