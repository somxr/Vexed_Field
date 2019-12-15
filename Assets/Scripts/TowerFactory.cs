using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    int towerNumber = 0;
    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerNumber < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            AddExistingTower();
        }
    }

    private static void AddExistingTower()
    {
        print("Tower limit reached");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = true;
        towerNumber++;
    }
}

