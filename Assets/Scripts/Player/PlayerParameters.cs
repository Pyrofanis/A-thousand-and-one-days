using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO-DO
//THIS SHOULDN'T BE A SEPERATE SCRIPT 
public class PlayerParameters : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    [HideInInspector]
    public bool canCarry = false, carrying = false, canShoot = false;
    [HideInInspector]
    public bool holdingObject = false;
    public float throwingSpeed;
    [HideInInspector]
    public Vector2 movement;
    public Transform newTurretPosition;
    [HideInInspector]
    public GameObject turretObj;
    [HideInInspector]
    public Vector2 clickVector;





    // Start is called before the first frame update
    void Start()
    {
        turretObj =null;



    }

    // Update is called once per frame
    void Update()
    {
        movement = GetComponent<PlayerMovement>().movement;
        clickVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("turret"))
        {
            turretObj = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("turret"))
        {
            turretObj = collision.gameObject;
        }
    }











}
