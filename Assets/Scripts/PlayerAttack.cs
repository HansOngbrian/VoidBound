using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject BulletPrefab;
    public Button AttackButton;
    public float AttackSpeed;

    bool _attacked;
    float _timer;

    void Update()
    {
        // attack aim is same as movement direction
        Vector3 aimDir = new Vector3(TwinSticks.Left.Horizontal, TwinSticks.Left.Vertical, 0);
        if(aimDir.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(transform.forward, -aimDir);
        }

        //attack cooldown timer
        if(_attacked)
        {
            _timer += Time.deltaTime;
            if(_timer >= 1 / AttackSpeed)
            {
                _attacked = false;
                _timer = 0;
                AttackButton.interactable = true;
            }
        }
    }

    public void SpawnBullet()
    {
        Instantiate(BulletPrefab, transform.position, transform.rotation * BulletPrefab.transform.rotation);
        AttackCooldown();
    }

    private void AttackCooldown()
    {
        _attacked = true;
        AttackButton.interactable = false;
    }
}
