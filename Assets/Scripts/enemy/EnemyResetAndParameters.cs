using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TO-DO 
//REWRITE THIS SHOULDN'T BE LIKE THIS


public class EnemyResetAndParameters : MonoBehaviour
{
    public int damage;
    [HideInInspector]
    public float currentHealth;
    public float maxhealth;
    public float initialHealth;
    public float speed;
    private Vector2 startinPosition;
    public List<int> enemyPathToUse;
    // Start is called before the first frame update
    void Start()
    {
       
        startinPosition = transform.position;
        initialHealth = currentHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
     if (currentHealth >= maxhealth)
        {
            Destroy(this.gameObject);            

        }
    }

    
  
  

   


}
