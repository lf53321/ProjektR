using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("Simplified") == 1)
        {
            GameObject.FindGameObjectWithTag("tagBackground").SetActive(false);
            GameObject snow = GameObject.FindGameObjectWithTag("tagSnow");
            if(snow != null) snow.SetActive(false);
            foreach(GameObject o in GameObject.FindGameObjectsWithTag("tagDescription")){
                o.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
