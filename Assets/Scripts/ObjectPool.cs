using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // 설명: 오브젝트 풀에 저장할 프리팹을 나타낸다.
    public GameObject prefab;
    // 설명: 오브젝트 풀의 부모를 나타낸다.
    public Transform parent;
    // 설명: 오브젝트 풀의 최대 개수를 나타낸다.
    public int maxObject = 30;
    // 설명: 오브젝트 풀을 나타낸다.
    List<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        // 설명: 오브젝트 풀을 초기화한다.
        pool = new List<GameObject>();
        // 설명: 오브젝트 풀에 오브젝트를 생성한다.
        for (int i = 0; i < maxObject; i++)
        {
            // 설명: 오브젝트를 생성한다.
            GameObject obj = Instantiate(prefab,parent);
            // 설명: 오브젝트를 비활성화한다.
            obj.SetActive(false);
            // 설명: 오브젝트를 오브젝트 풀에 추가한다.
            pool.Add(obj);
        }
    }
    // 설명: 오브젝트 풀에서 오브젝트를 가져온다.
    public GameObject Get()
    {
        // 설명: 오브젝트 풀에서 비활성화된 오브젝트를 찾아 반환한다.
        foreach (GameObject obj in pool)
        {
            // 설명: 오브젝트가 비활성화되어 있으면 반환한다.
            if (!obj.activeInHierarchy)
            {
                // 설명: 오브젝트를 반환한다.
                obj.SetActive(true);
                // 설명: 오브젝트를 반환한다.
                return obj;
            }
        }
        // 설명: 오브젝트 풀에 더 이상 오브젝트가 없으면 null을 반환한다.
        return null;
    }

}
