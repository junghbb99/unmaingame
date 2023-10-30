using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 설명: 플레이어를 나타낸다.
    public GameObject player;
    // 설명: 적을 생성하는 간격을 나타낸다.
    public float spawnTerm = 5;
    // 설명: 적의 생성 간격이 줄어드는 양을 나타낸다.
    public float fasterEverySpawn = 0.05f;
    // 설명: 적의 생성 간격이 줄어들 수 있는 최소값을 나타낸다.
    public float minSpawnTerm = 1;
    public TextMeshProUGUI scoreText;
    float timeAfterLastSpawn;
    // 설명: 플레이어의 점수를 나타낸다.
    float score;
    // Start is called before the first frame update
    void Start()
    {
        // 설명: 게임을 초기화한다.
        timeAfterLastSpawn = 0;
        // 설명: 플레이어의 점수를 초기화한다.
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 설명: 적을 생성한다.
        timeAfterLastSpawn += Time.deltaTime;
        // 설명: 플레이어의 점수를 증가시킨다.
        score += Time.deltaTime;
        // 설명: 적을 생성한다.
        if (timeAfterLastSpawn > spawnTerm)
        {
         
            timeAfterLastSpawn -= spawnTerm;
            
            SpwanEnemy();
            // 설명: 적의 생성 간격을 줄인다.
            spawnTerm -= fasterEverySpawn;
            if (spawnTerm < minSpawnTerm)
            {
                spawnTerm = minSpawnTerm;
            }
        }
        // 설명: 플레이어의 점수를 표시한다.
        scoreText.text = ((int)score).ToString();
    }
    // 설명: 적을 생성한다.
    void SpwanEnemy()
    {
        float x = Random.Range(-9f, 9f);
        float y = Random.Range(-4.5f, 4.5f);

        GameObject obj = GetComponent<ObjectPool>().Get();
        obj.transform.position = new Vector3(x,y,0);
        obj.GetComponent<EnemyController>().Spawn(player);
    }
}

