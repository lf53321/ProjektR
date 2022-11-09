using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float powerValue = 100f;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI powerText;

    public float time = 0f;

    public Rigidbody2D rb;

    Vector2 movement;
    

    private void Start()
    {
        Time.timeScale = 1;
        InvokeRepeating("PowerUpdate", 0f, 1f);
    }

    public ScreenScript screenScript;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        time += Time.deltaTime;
        timeText.text = "Time: " + time.ToString("0.0").Replace(',','.');

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void PowerUpdate()
    {
        if (powerValue <= 0f)
        {
            screenScript.gameOver(time);
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        powerText.text = --powerValue + "%";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.name.Equals("PowerStation(Clone)"))
        {
            Debug.Log("hit");
            Debug.Log(collision.gameObject.name);
            screenScript.gameOver(time);
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            collision.gameObject.SetActive(false);
            if (powerValue <= 70f)
            {
                powerValue += 30;
            }
            else
            {
                powerValue = 100f;
            }
            time += 5f;
        }
    }
}
