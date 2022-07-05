using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementWithWaypoints : MonoBehaviour
{

    //TO-DO
    //MOVE ΙΤ SOMEWHERE ELSE
    //MAYBE TO A MOVEMENT CONTROLLER


    private EnemyPaths enemyPathnWaypoints;
    [HideInInspector]
    public int pathIndex, waypointIndex;
    //private SpawnManager spawnMng;
    private EnemyResetAndParameters enemyStats;
    private GameObject spawnManager;
    private Vector3 enemyObjectivePos;
    


    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager");
        enemyPathnWaypoints = spawnManager.GetComponent<EnemyPaths>();
        enemyStats = gameObject.GetComponent<EnemyResetAndParameters>();
        pathIndex = Random.Range(0, enemyStats.enemyPathToUse.Count);
        waypointIndex = 0;
        transform.position = enemyPathnWaypoints.enemyPaths[enemyStats.enemyPathToUse[pathIndex]].waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(enemyStats.enemyPathToUse.Count + "to count "+gameObject.name+" the number is "+enemyStats.enemyPathToUse[pathIndex]);
        enemyMovement();
      
    }
    public void enemyMovement()
    {
        enemyObjectivePos = enemyPathnWaypoints.enemyPaths[enemyStats.enemyPathToUse[pathIndex]].waypoints[waypointIndex].transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, enemyObjectivePos, enemyStats.speed* Time.deltaTime);
        if (this.gameObject.transform.position == enemyObjectivePos)
        {
            waypointIndex++;
        }
        if (waypointIndex >= enemyPathnWaypoints.enemyPaths[enemyStats.enemyPathToUse[pathIndex]].waypoints.Count)
        {
            Destroy(this.gameObject);
        }
    }
 
}
