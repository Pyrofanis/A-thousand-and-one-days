using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uIscripts : MonoBehaviour
{
    public string sceneName;
    public GameObject pauseMenu,deadPanel,mainMenu,WinningPanel;
    public GameObject wallHealthOBJ,waveIndexObj;
    public GameObject waveIndexTXTobj;
    [HideInInspector]
    public bool winningPannelActivate=false;


    // Start is called before the first frame update
    void Start()
    {
        wallHealthOBJ = GameObject.FindGameObjectWithTag("wall");
        waveIndexObj = GameObject.FindGameObjectWithTag("SpawnManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            pauseMenu.SetActive(true);

        }
        if (pauseMenu.activeSelf || mainMenu.activeSelf)
        {
            Time.timeScale = 0;

        }
        else if (pauseMenu.activeSelf== false || mainMenu.activeSelf) {
            Time.timeScale = 1;

        }
        if (winningPannelActivate)
        {
            WinningPanel.SetActive(true);

        }
       
       
        WaveIndicateVoid();

    }
    public void LoadingScenes(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
 

    }
    public void SceneQuiting()
    {
        Application.Quit();
    }
    public void WaveIndicateVoid()
    {
        waveIndexTXTobj.GetComponent<Text>().text = "Wave:" + (waveIndexObj.GetComponent<SpawnManager>().waveNumber + 1);
    }



}
