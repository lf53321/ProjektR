using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{

    public float moveSpeed = 5f;

    public TextMeshProUGUI textMeshProUGUI;

    public float time = 0f;

    public Rigidbody2D rb;

    Vector2 movement;
    

    private void Start()
    {
        Time.timeScale = 1;
    }

    public ScreenScript screenScript;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        time += Time.deltaTime;
        textMeshProUGUI.text = "Time: " + time.ToString("0.0").Replace(',','.');

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        screenScript.gameOver(time);
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
