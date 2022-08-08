using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectile_particles;
    [SerializeField] float hit_range = 15f;

    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closest_target = null;
        float max_distance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float target_distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (target_distance < max_distance)
            {
                closest_target = enemy.transform;
                max_distance = target_distance;
            }
        }

        target = closest_target;
    }

    void AimWeapon()
    {
        float target_distance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (target_distance < hit_range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool condition)
    {
        var emission_module = projectile_particles.emission;
        emission_module.enabled = condition;
    }
}
