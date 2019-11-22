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
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
