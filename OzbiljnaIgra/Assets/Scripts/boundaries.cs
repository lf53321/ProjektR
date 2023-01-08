using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public Player player;
    public backgroundScript backgroundScript;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;    
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;    
    }


    void LateUpdate()
    {
        GameObject gameObject = GameObject.Find("PowerStation(Clone)");
        Vector3 viewPos = transform.position;
        if (gameObject != null)
        {
            if (gameObject.transform.position.x < 0)
            {
                viewPos.x = Mathf.Clamp(viewPos.x, -4.5f + objectWidth, 2.95f - objectWidth);
            }
            else
            {
                viewPos.x = Mathf.Clamp(viewPos.x, -3f + objectWidth, 4.45f - objectWidth);
            }
        }
        else if (player.moveSpeed > 3f)
        {
            viewPos.x = Mathf.Clamp(viewPos.x, -3f + objectWidth, 2.95f - objectWidth);
        }
        backgroundScript.scroolSpeed = player.moveSpeed * 2;
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
