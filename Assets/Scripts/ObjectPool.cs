using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject prefab;
    public int maxObject = 30; 
    List<GameObject> pool;
    // Start is called before the first frame update
    void Start()
    {
        pool = new List<GameObject>();

        for (int i=0; i<maxObject; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
