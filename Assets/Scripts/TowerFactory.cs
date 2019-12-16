using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    int towerNumber = 0;

    //create empty queue of towers
    Queue<Tower> TowerQ = new Queue<Tower>();

    public void AddTower(Waypoint newBaseWaypoint)
    {
        towerNumber = TowerQ.Count;

        if (towerNumber < towerLimit)
        {
            InstantiateNewTower(newBaseWaypoint);
        }
        else
        {
            MoveExistingTower(newBaseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        Tower oldTower = TowerQ.Dequeue(); //Dequeue oldest tower

        oldTower.baseWaypoint.isPlaceable = true; //set placeable flags
        newBaseWaypoint.isPlaceable = false;

        oldTower.transform.position = newBaseWaypoint.transform.position;
        oldTower.baseWaypoint = newBaseWaypoint; //set the basewaypoints

        TowerQ.Enqueue(oldTower);  //Put the old tower on top of the queue
    }

    private void InstantiateNewTower(Waypoint newBaseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, newBaseWaypoint.transform.position, Quaternion.identity, this.transform);
        newTower.baseWaypoint = newBaseWaypoint;

        TowerQ.Enqueue(newTower);
        
        newBaseWaypoint.isPlaceable = false;
    }
}

