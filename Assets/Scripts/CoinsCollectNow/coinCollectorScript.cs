using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinCollectorScript : MonoBehaviour
{

    //TO-DO 
    //MAKE THIS INTO COLLECTIBLE SPAWNER
    //MOVE UPGRADES TO UPGRADE MANAGER OR GAME MANAGER


    //public GameObject coinsGatheredTextobj;
    public int coinsToUpgrade=0,coinMultiplier;
    private int spawnLocsIndex;
    public GameObject coinsGatheredTextobj;
    [HideInInspector]
    public int coinsGathered = 0;
    public List<Transform> SpawnLocs;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coinsGathered < coinsToUpgrade * coinMultiplier)
        {
            coinsGatheredTextobj.GetComponent<Text>().text = coinsGathered.ToString() + "/" + coinsToUpgrade.ToString();
        }
        else
        {
            coinsGatheredTextobj.GetComponent<Text>().text = "You are drunk GZ";

        }
        if (spawnLocsIndex >= SpawnLocs.Count - 1)
        {
            spawnLocsIndex = 0;
        }
    }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag =="collectible")
            {   
                CollectibleRectanglePosition(collision.gameObject);
                spawnLocsIndex++;
            if (coinsGathered < coinsToUpgrade && coinsGathered < coinsToUpgrade - coinMultiplier)
            {
                coinsGathered = coinsGathered + coinMultiplier;

            }
            else 
            {
                coinsGathered = coinsToUpgrade;
                collision.gameObject.SetActive(false);
                }
        }
             
        Debug.Log("KOLAI");
    }
    private void CollectibleRectanglePosition(GameObject collectible) //respawns object to spawn locations
    {
        //spawnLocsIndex = Random.Range(0, SpawnLocs.Count);
        //if (SpawnLocs[spawnLocsIndex].transform.position != collectible.transform.position)
        //{
        //    collectible.transform.position = SpawnLocs[spawnLocsIndex].transform.position;
        //}
        collectible.transform.position = SpawnLocs[spawnLocsIndex].transform.position;


    }


}
