using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO-DO
//THIS SHOULDN'T BE A SEPERATE SCRIPT
public class towerParameters : MonoBehaviour
{
    //public GameObject arrow;
    public int towerDMG;
    public float reloadDelay,shootinSpeed,radius,boltSpeed,boltdmg;
    public float turretRespawnDelay;
    public GameObject boltPrefab;
    public float boltLifeSpam;
    public LayerMask enemieLayer,towerLayer;
    public Vector3 radiousOffset=new Vector3(0,0,0);
    public float towerReturnDistanceOffset,towerDetectorRadious;
    [HideInInspector]
    public bool canShoot;
    [HideInInspector]
    public Collider2D[] towersNearby;
    // Start is called before the first frame update
    void Start()
    {

        canShoot = GameObject.FindObjectOfType<PlayerParameters>().canShoot;

    }

    // Update is called once per frame
    void Update()
    {
        checkIfTowerNearby();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + radiousOffset, radius);
        Gizmos.DrawWireSphere(transform.position, towerDetectorRadious);

    }
    private void checkIfTowerNearby()//checks a table of towers this can work with multiple turrets not only with 2
    {
        towersNearby = Physics2D.OverlapCircleAll(transform.position, towerDetectorRadious, towerLayer);
        if (towersNearby.Length != 0)
        {
            canShoot = false;
            foreach (Collider2D coli in towersNearby)
            {
                coli.gameObject.GetComponent<towerParameters>().canShoot = false;
            }
        }
        else if (!GameObject.FindObjectOfType<PlayerParameters>().carrying)
        {
            canShoot = true;
            foreach (Collider2D coli in towersNearby)
            {
                coli.gameObject.GetComponent<towerParameters>().canShoot = true;
            }
        }
    }



}
