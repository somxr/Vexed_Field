using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem bullets;
    [SerializeField] float enemyRange;
    EnemyController [] enemies;



    //State of each tower
    Transform targetEnemy;
    public Waypoint baseWaypoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy.transform);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, targetEnemy.position);

        if(distanceToEnemy < enemyRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        enemies = GameObject.FindObjectsOfType<EnemyController>();
        if (enemies.Length == 0)
        {
            return;
        }



        Transform closestEnemy = enemies[0].transform;


        foreach (EnemyController testEnemy in enemies)
        {
            closestEnemy = GetClosest(testEnemy.transform, closestEnemy);
        }
        targetEnemy = closestEnemy;

    }

    Transform GetClosest(Transform transformA, Transform transformB)
    {
        float distanceA = Vector3.Distance(transform.position, transformA.position);
        float distanceB = Vector3.Distance(transform.position, transformB.position);

        if(distanceA<distanceB)
        {
            return transformA;
        }

        return transformB;
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = bullets.emission;
        emissionModule.enabled = isActive;
    }

    //private void CheckIfEnemyExists()
    //{
    //    //float shortestDistance = Mathf.Infinity;
    //    enemies = GameObject.FindObjectsOfType<EnemyController>();

    //    if (enemies.Length == 0)
    //    {
    //        Shoot(false);
    //        return;
    //    }

    //    AimAtClosestEnemy();
    //}

    //private void AimAtClosestEnemy()
    //{
    //    float shortestDistance = Mathf.Infinity;

    //    foreach (EnemyController enemy in enemies)
    //    {
    //        Vector3 enemyPosition = enemy.transform.position;
    //        float enemyDistance = Vector3.Distance(transform.position, enemyPosition);

    //        if (enemyDistance < shortestDistance)
    //        {
    //            objectToPan.LookAt(enemy.transform);

    //            if (enemyDistance < enemyRange)
    //            {
    //                Shoot(true);
    //            }
    //            else
    //            {
    //                Shoot(false);
    //            }
    //        }
    //    }
    //}


}
