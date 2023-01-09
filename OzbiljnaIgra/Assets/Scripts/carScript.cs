using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class carScript : MonoBehaviour
{
    public Sprite simpleSprite;
    public Sprite[] sprites;
    private SpriteRenderer SpriteRenderer;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        SpriteRenderer = this.GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetFloat("Simplified") == 1)
        {
            SpriteRenderer.sprite = simpleSprite;
        }
        else
        {
            SpriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 0 - screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }

}
