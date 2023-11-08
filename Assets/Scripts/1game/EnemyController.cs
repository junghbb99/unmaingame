using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemyController : MonoBehaviour
{
    //설명: 적의 상태를 나타낸다.
    enum State
    {
        //설명: 적이 생성되는 상태
        Spawning,
        Moving,
        Dying
    }
    //설명: 적의 속도를 나타낸다.
    public float speed = 2;
    
    public Material flashMaterial;
    public Material defaultMaterial;
    //설명: 적이 플레이어를 향해 이동한다.
    GameObject target;
    //설명: 적의 상태를 나타낸다.
    State state;

    // Start is called before the first frame update
    void Start()
    { 

    }

    public void Spawn(GameObject target)
    {
        this.target = target;
        state = State.Spawning;
        GetComponent<Character>().Initialize();
        GetComponent<Animator>().SetTrigger("Spawn");
        Invoke("StartMoving", 1);
        GetComponent<Collider2D>().enabled = false;
    }
    
    void StartMoving()
    {
        state = State.Moving;
        GetComponent<Collider2D>().enabled = true;
    }

    private void FixedUpdate()
    {
        // 적이 플레이어를 향해 이동한다.
        if (state==State.Moving)
        {
            
                    Vector2 direction = target.transform.position - transform.position;
                    
                    transform.Translate(direction.normalized * speed * Time.fixedDeltaTime);
                    // 적이 플레이어를 향해 바라본다.
                    if (direction.x<0)
                    {
                        GetComponent<SpriteRenderer>().flipX = true;
                    }
            
                    if (direction.x>0)
                    {
                        
                        GetComponent<SpriteRenderer>().flipX = false;
                    }
        }

    }

    //설명: 적이 총알에 맞으면 죽는다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 총알에 맞으면 죽는다.
        if (collision.tag =="Bullet")
        {
            // 총알의 데미지를 가져온다.
            float d = collision.gameObject.GetComponent<Bullet>().damage;
            // 적의 체력을 깎는다.
            if ( GetComponent<Character>().Hit(d))
            {
                // 살아있을 때
                FIash();
            }
            else
            {
                // 죽었을 때
                Die();
            }
          
        }
    }
    // 설명: 적이 총알에 맞으면 깜빡인다.
    void FIash()
    {
        GetComponent<SpriteRenderer>().material = flashMaterial;
        Invoke("AfterFIash", 0.5f);
    }
    // 설명: 적이 총알에 맞으면 깜빡인다.
    void AfterFIash()
    {
        GetComponent<SpriteRenderer>().material = defaultMaterial;
    }
    // 설명: 적이 총알에 맞으면 죽는다.
    void Die()
    {
        
        state = State.Dying;
        // 죽는 애니메이션 재생
        GetComponent<Animator>().SetTrigger("Die");
        Invoke("AfterDying", 1.4f);
    }
    
    void AfterDying()
    {
        // 죽은 후 처리
       gameObject.SetActive(false);
    }
}
