using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] // adds in enemy script when adding the enemyhealth script
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int max_hit_point = 5;
    
    [Tooltip("Adds amount to max_hit_point when enemy dies.")]
    [SerializeField] int difficulty_ramp = 1;
    
    int current_hit_point = 0;
    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        current_hit_point = max_hit_point;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        current_hit_point--;

        if (current_hit_point <= 0)
        {
            gameObject.SetActive(false);
            max_hit_point += difficulty_ramp;
            enemy.RewardGold();
        }
    }
}
