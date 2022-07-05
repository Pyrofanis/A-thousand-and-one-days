using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TO-DO RENAME AND MOVE IT TO SCRIPTABLE-UTILITIES FOLDER

[System.Serializable]
public class waypointList
{
    public List<GameObject> waypoints;
}

public class EnemyPaths : MonoBehaviour
{
    public List<waypointList> enemyPaths;
     
}