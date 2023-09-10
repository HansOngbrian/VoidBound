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
    public GameObject AttackPrefab;
    public Button AttackButton;
    public bool Meele;
    public float MeeleDur;
    public float AttackSpeed;

    bool _attacked;
    float _timer;

    private void Start()
    {
        AttackButton.onClick.AddListener(Attack);
    }

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

    public void Attack()
    {
        if (!Meele)
        {
            Instantiate(AttackPrefab, transform.position, transform.rotation * AttackPrefab.transform.rotation);
            AttackCooldown();
        }
        else
        {
            StartCoroutine(MeeleAttack());
            AttackCooldown();
        }
    }

    private void AttackCooldown()
    {
        _attacked = true;
        AttackButton.interactable = false;
    }

    private IEnumerator MeeleAttack()
    {
        GameObject go = Instantiate(AttackPrefab, transform);
        yield return new WaitForSeconds(MeeleDur);
        Destroy(go);
    }
}
