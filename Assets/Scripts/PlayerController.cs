using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3;
    public GameObject BulletPrefab;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move += new Vector3(-1,0,0);
        }
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move += new Vector3(1,0,0);
        }
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            move += new Vector3(0,1,0);
        }
        
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move += new Vector3(0,-1,0);
        }

        if (move.magnitude > 0)
        {
            GetComponent<Animator>().SetTrigger("Move");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Stop");
        }

 

        move = move.normalized;
        if (move.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (move.x>0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetMouseButtonDown(0))
                 {
                     Shoot();
                 }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void Shoot()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(worldPosition);
        worldPosition.z = 0;
        worldPosition  -= (transform.position + new Vector3(0, -0.5f,0));
        
        GameObject newBullet = Instantiate<GameObject>(BulletPrefab);
        newBullet.transform.position = transform.position + new Vector3(0,-0.5f);
        newBullet.GetComponent<Bullet>().Direction = worldPosition;

    }

    private void FixedUpdate()
    {
        transform.Translate(move * (speed * Time.deltaTime));
    }
}
