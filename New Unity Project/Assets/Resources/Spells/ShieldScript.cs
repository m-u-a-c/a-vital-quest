using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

    
    public float destroytime = 3;
    float timeleft;
    // Use this for initialization
    void Start()
    {
        timeleft = destroytime;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        


        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {
            Destroy(gameObject);
            timeleft = destroytime;
        }
    }
}
