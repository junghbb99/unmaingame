using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // 설명: 캐릭터의 체력을 나타낸다.
    public float MaxHP = 3;
    
   float HP;
    // Start is called before the first frame update
    void Start()
    {  
        // 설명: 캐릭터의 체력을 초기화한다. 
        HP = MaxHP;
    }
    // 설명: 캐릭터가 총알에 맞으면 죽는다.
    public bool Hit(float damage)
    {
        // 설명: 캐릭터의 체력을 감소시킨다.
        HP -= damage;
        // 설명: 캐릭터의 체력이 0이하이면 0으로 만든다.
        if (HP<0)
        {
        // 설명: 캐릭터가 죽는다.
            HP = 0;
        }
        // 설명: 캐릭터가 살아있으면 true를 반환한다.
        return HP > 0;
    }
}
