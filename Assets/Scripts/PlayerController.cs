using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerController : MonoBehaviour
{
    // 설명: 플레이어의 속도를 나타낸다.
    public float speed = 3;
    // 설명: 총알의 프리팹을 나타낸다.
    public GameObject BulletPrefab;
    
    public Material flashMaterial;
    public Material defaultMaterial;
    // 설명: 총알의 발사 속도를 나타낸다.
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 설명: 플레이어를 이동시킨다.
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

 
    // 설명: 플레이어가 마우스를 클릭하면 총알을 발사한다.
        move = move.normalized;
        if (move.x < 0)
        {
            // 설명: 플레이어가 왼쪽을 바라본다.
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (move.x>0)
        {
            // 설명: 플레이어가 오른쪽을 바라본다.
            GetComponent<SpriteRenderer>().flipX = false;
        }
        // 설명: 플레이어가 마우스를 클릭하면 총알을 발사한다.
        if (Input.GetMouseButtonDown(0))
                 {
                     // 설명: 총알을 발사한다.
                     Shoot();
                 }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void Shoot()
    {
        // 설명: 총알을 발사한다.
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     
        // 설명: 총알의 위치를 설정한다.
        worldPosition.z = 0;
        worldPosition  -= (transform.position + new Vector3(0, -0.5f,0));
        // 설명: 총알을 생성한다.
        GameObject newBullet = GetComponent<ObjectPool>().Get();
        
        if (newBullet != null)
        {   
            // 설명: 총알의 위치를 설정한다.
            newBullet.transform.position = transform.position + new Vector3(0,-0.5f);
            // 설명: 총알의 이동 방향을 설정한다.
            newBullet.GetComponent<Bullet>().Direction = worldPosition;
        }


    }
   
    private void FixedUpdate()
    {
        // 설명: 플레이어를 이동시킨다.
        transform.Translate(move * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<Character>().Hit(1))
        {
            FIash();
        }
        else
        {
            Die();
        }
        
        
    }
    
    // 설명: 플레이어가 총알에 맞으면 깜빡인다.
    void FIash()
    {
        GetComponent<SpriteRenderer>().material = flashMaterial;
        Invoke("AfterFIash", 0.5f);
    }
    // 설명: 플레이어가 총알에 맞으면 깜빡인다.
    void AfterFIash()
    {
        GetComponent<SpriteRenderer>().material = defaultMaterial;
    }
    void Die()
    {
        
   
        // 죽는 애니메이션 재생
        GetComponent<Animator>().SetTrigger("Die");
        Invoke("AfterDying", 0.075f);
    }
    
    void AfterDying()
    {
        // 죽은 후 처리
        //gameObject.SetActive(false);
    }
}

