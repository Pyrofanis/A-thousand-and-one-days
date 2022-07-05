using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//TO-DO
//THIS SHOULDN'T BE ON A SEPERATE SCRIPT

public class EnemyWavesParameters : MonoBehaviour
{
    [HideInInspector]
    public int maxEnemies=0 ;
    public int nextWaveStartDelay;
    public int numberOfEnemyTypes;
    public float enemySpawningRate;
    private int existingEnemiesCounter = 0;
    [HideInInspector]
    public List<GameObject> currentEnemies;
    public List<int> enemiesInThisRound;

    

    // Start is called before the first frame update
    void Start()
    {

       
        for (int i = 0; i < enemiesInThisRound.Count; i++)
        {
            maxEnemies = maxEnemies + enemiesInThisRound[i];
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies.Count >= maxEnemies)
        {

            foreach (GameObject actvEnm in currentEnemies)
            {
                if (actvEnm == null)
                {
                    existingEnemiesCounter++;
                }
                if (actvEnm != null)
                {
                    existingEnemiesCounter = 0;
                }
            }

        }
        if (existingEnemiesCounter >= maxEnemies)
        {
            StartCoroutine(waveChangeDelay());
        }
            //Debug.LogWarning(existingEnemiesCounter + " posoi pethanas");

    }
    IEnumerator waveChangeDelay()
    {

    

        if (existingEnemiesCounter >= maxEnemies)
        {

            //currentEnemies.Clear();
            yield return new WaitForSeconds(nextWaveStartDelay);
          
            SceneManager.LoadScene("ArtsySetUpScene");

        }
    }
  
}
