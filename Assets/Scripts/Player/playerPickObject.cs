using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO-DO 
//MAKE IT GENERAL
//EXECUTE BY ANY OBJECT

public class playerPickObject : MonoBehaviour
{
   
    private Transform newTurretPosition;
    private GameObject turret;
    private PlayerParameters player;

    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.FindGameObjectWithTag("turret");
        player = GetComponent<PlayerParameters>();

    }

    // Update is called once per frame
    void Update()
    {
        newTurretPosition = player.newTurretPosition;
        PickUpObj();

    }
    private void PickUpObj()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.canCarry)
        {
           player.carrying = true;
            player.holdingObject = true;



        }
        if (Input.GetKeyUp(KeyCode.Space))
        {

            player.carrying = false;
            player.holdingObject = false;


        }

        if (player.carrying)
        {
            turret.GetComponent<Transform>().position = newTurretPosition.position;
            turret.GetComponent<towerParameters>().canShoot=false;


        }
        else
        {
            player.carrying = false;
            player.holdingObject = false;
            turret.GetComponent<towerParameters>().canShoot = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("turret")&& !player.carrying)
        {
            player.canCarry = true;
            turret = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("turret"))
        {
            player.canCarry = false;
        }
    }
}
