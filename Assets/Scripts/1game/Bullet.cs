using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 설명: 총알의 속도를 나타낸다.
    public float speed = 10;

    // 설명: 총알의 데미지를 나타낸다.
    public float damage = 1;

    // 설명: 총알의 이동 방향을 나타낸다.
    Vector2 direction;

    // 설명: 총알의 이동 방향을 설정한다.
    public Vector2 Direction
    {
        // 설명: 총알의 이동 방향을 설정한다.
        set { direction = value.normalized; }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 설명: 총알을 이동시킨다.
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // 설명: 총알이 벽이나 적에게 맞으면 사라진다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 설명: 총알이 벽이나 적에게 맞으면 사라진다.
        if (collision.tag == "Wall" || collision.tag == "Enemy")
        {
            // 설명: 총알을 비활성화한다.
            gameObject.SetActive(false);
        }
    }
}