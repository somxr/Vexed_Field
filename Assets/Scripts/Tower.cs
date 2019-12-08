using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform targetEnemy;
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem bullets;
    [SerializeField] float enemyRange;
    EnemyController [] enemies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        CheckIfEnemyExists();
    }

    private void CheckIfEnemyExists()
    {
        //float shortestDistance = Mathf.Infinity;
        enemies = GameObject.FindObjectsOfType<EnemyController>();

        if (enemies.Length == 0)
        {
            Shoot(false);
            return;
        }

        AimAtClosestEnemy();
    }

    private void AimAtClosestEnemy()
    {
        float shortestDistance = Mathf.Infinity;

        foreach (EnemyController enemy in enemies)
        {
            Vector3 enemyPosition = enemy.transform.position;
            float enemyDistance = Vector3.Distance(transform.position, enemyPosition);

            if (enemyDistance < shortestDistance)
            {
                objectToPan.LookAt(enemy.transform);

                if (enemyDistance < enemyRange)
                {
                    Shoot(true);
                }
                else
                {
                    Shoot(false);
                }
            }
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = bullets.emission;
        emissionModule.enabled = isActive;
    }
}
