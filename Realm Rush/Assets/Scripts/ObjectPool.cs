using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy_prefab;
    [SerializeField] [Range(0, 50)]int pool_size = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawn_timer = 1f; 

    GameObject[] pool;

    void Awake() 
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[pool_size];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy_prefab, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectPool();
            yield return new WaitForSeconds(spawn_timer);
        }
    }

    void EnableObjectPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
