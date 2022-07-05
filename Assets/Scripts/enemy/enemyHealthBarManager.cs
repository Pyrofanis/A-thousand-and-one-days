using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//TO-DO
//MOVE IT TO UI MANAGER

public class enemyHealthBarManager : MonoBehaviour
{
    //public float healthbarScale;
    //public Vector3 localScaleATruntime;
    public Slider enemyHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthSlider.maxValue = gameObject.GetComponent<EnemyResetAndParameters>().maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarChangeScale();
        
    }
    void HealthBarChangeScale()
    {
        enemyHealthSlider.value = gameObject.GetComponentInParent<EnemyResetAndParameters>().currentHealth; 
        //if (enemyHealthSlider.value>enemyHealthSlider.maxValue)
        //{
        //    enemyHealthSlider.value = 0;
        //}

    }
}
