using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScaler : MonoBehaviour
{
    private WallScript wallScript;
    // Start is called before the first frame update
    void Start()
    {
        wallScript = GameObject.FindObjectOfType<WallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale =new Vector2 ((wallScript.maxWallHealth - wallScript.currentWallHealth) / wallScript.maxWallHealth, (wallScript.maxWallHealth - wallScript.currentWallHealth) / wallScript.maxWallHealth);
        Debug.Log((wallScript.maxWallHealth - wallScript.currentWallHealth) / wallScript.maxWallHealth);
    }
}
