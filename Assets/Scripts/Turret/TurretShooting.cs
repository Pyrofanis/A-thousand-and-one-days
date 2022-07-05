using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

//TO-DO
//MAKE IT GENERAL
//EVERY OBJECT SHOULD HAVE THE RIGHT TO ARMS
public class TurretShooting : MonoBehaviour

{   
    private towerParameters tower;
    private float smallestDistance;
    [HideInInspector]
    public Collider2D enemyToShoot;
    [HideInInspector]
    private float timer;
    [HideInInspector]
    public Collider2D[] currentEnemiesInScene;
    [HideInInspector]
    public List<GameObject> currentBolts=null; //public gia na exoun prosbasei kai h dyo pirgoi h osoi einai genikos
    //private moveTowerToPoint moveTowerToPoint;

    // Start is called before the first frame update
    void Start()
    {
        tower =this.gameObject.GetComponent<towerParameters>();
        smallestDistance = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {




    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        FindClosestEnemy();
        if (timer >= tower.reloadDelay && enemyToShoot!=null)
        {   if (tower.canShoot)
            {
                Shoot();
            }
            timer = 0;
        }

    }


    //in order to chase and destroy coin add coin to the same layer as enemies
    private void FindClosestEnemy()
    { 
        enemyToShoot = null;
       currentEnemiesInScene=(Physics2D.OverlapCircleAll(transform.position+tower.radiousOffset, tower.radius, tower.enemieLayer));
       
        foreach (Collider2D enemyIndex in currentEnemiesInScene)
        {
            float distance = (transform.position+tower.radiousOffset - enemyIndex.transform.position).sqrMagnitude;
           
                if (smallestDistance > distance)
                {
                    smallestDistance = distance;
                    enemyToShoot = enemyIndex;
                    Debug.DrawLine(this.transform.position, enemyIndex.transform.position);
                }
            
            if (enemyToShoot == null)
            {
                smallestDistance = Mathf.Infinity;
            }
        }

    }
    public void Shoot()
    {

      currentBolts.Add(Instantiate(tower.boltPrefab,tower.transform.position+tower.radiousOffset, Quaternion.identity));

        if (currentBolts != null)
        {
            currentBolts[currentBolts.Count - 1].GetComponent<BoltSeekTarget>().towerParameters = this.gameObject.GetComponent<towerParameters>();
        }
        else
        {
            currentBolts.Clear();
        }
    }

} 
