using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public GameObject player;

    Vector2 vector;

    // Start is called before the first frame update
    void Start()
    {
        vector = transform.position - player.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 position = this.transform.position;
        position.x = player.transform.position.x + vector.x;
        position.y = player.transform.position.y + vector.y;
        this.transform.position = position;
    }
}
