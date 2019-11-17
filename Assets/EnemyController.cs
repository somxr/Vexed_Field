using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintWaypoints());
    }

    IEnumerator PrintWaypoints()
    {
        print("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            print("Visiting Block: " + waypoint);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
