using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Required Features
    Move bullet towards enemy
    Deal Damage to enemy

Editable in editor
    Movement speed
    Damage
*/

public class Bullet : MonoBehaviour
{
    public float TimeToDestray=10;
    public float Speed = 10;
    public int Damage;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeToDestray);
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * Speed*Time.deltaTime);
    }
    // Update is called once per frame
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
