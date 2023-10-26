using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10;
    public float damage = 1;

    Vector2 direction;

    public Vector2 Direction
    {
        set { direction = value.normalized; }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Direction = new Vector2(10, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
    
    }
}
