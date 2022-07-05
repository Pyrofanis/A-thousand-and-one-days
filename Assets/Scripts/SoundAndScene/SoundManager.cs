using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get { return instance; }
    }
    void Start()
    {
        
    }
    private void Awake()
    {
        if (instance != null) {
            Destroy(this.gameObject);
            return;
        } else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
