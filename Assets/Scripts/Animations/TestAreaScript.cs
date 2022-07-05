using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestAreaScript : MonoBehaviour
{
    public Transform areaEdgeTransf;
    public float respawnDelay;
    public float timer = 0;
    private int index=0;
    public List<Transform> spawnPoints;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = spawnPoints[index].transform.position;
        timer += Time.deltaTime;
        if (timer >= respawnDelay)
        {
            index++;
            timer = 0;
        }
        if (spawnPoints.Count-1<= index)
        {
            index = 0;
        }
    }

}
