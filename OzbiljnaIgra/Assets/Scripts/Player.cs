using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public Sprite simpleSprite;
    public float maxSpeed = 7f;
    public float minSpeed = 5f;
    public float moveSpeed = 5f;
    public float powerValue = 58.0f;
    public float distanceValue = 0f;
    public float distanceThreshold = 113f;
    public float speedValue = 60f;
    public float consumptionValue = 20f;
    public float minConsumption = 20f;
    public float maxConsumption = 35f;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI consumptionText;
    public TextMeshProUGUI chargingText;

    public GameObject chargingBackgroundImage;
    public GeneratePowerStation generatePowerStation;

    modalWindows modalniProzor;

    public float time = 0f;

    public Rigidbody2D rb;

    Vector2 movement;
    

    private void Start()
    {
        if (PlayerPrefs.GetFloat("Simplified") == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = simpleSprite;
        }
        Time.timeScale = 0;
        powerValue = 58.0f;
        distanceText.text = distanceValue.ToString() + "/100km";
        speedText.text = speedValue.ToString() + "km/h";
        consumptionText.text = consumptionValue.ToString() + "kWh";
        InvokeRepeating("PowerUpdate", 0f, 1f);
        InvokeRepeating("DistanceUpdate", 0f, 1f);
        InvokeRepeating("SpeedUpdate", 0f, 0.125f);

        try{
        modalniProzor = GameObject.FindGameObjectWithTag("tagModalniProzor").GetComponent<modalWindows>();
        modalniProzor.pokreniIntroduction();} catch{    }
    }
   

    public ScreenScript screenScript;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        time += Time.deltaTime;
        timeText.text = time.ToString("0.0").Replace(',','.') + " min";

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void PowerUpdate()
    {
        if (powerValue <= 0f)
        {
            screenScript.gameOver(time, false);
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        powerValue -= consumptionValue / 60;
        powerText.text = string.Format("{0:F1}", powerValue) + " kWh";
    }
    
    void DistanceUpdate()
    {
        if (distanceValue >= distanceThreshold)
        {
            screenScript.gameOver(powerValue * distanceValue - time, true);
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        distanceValue += speedValue / 60;
        distanceText.text = string.Format("{0:F0}", distanceValue) + "/" + distanceThreshold +"km";
    }

    void SpeedUpdate()
    {
        if(moveSpeed != 0 && chargingBackgroundImage.activeInHierarchy)
        {
            chargingText.text = "";
            chargingBackgroundImage.SetActive(false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (moveSpeed < maxSpeed)
            {
                moveSpeed += 0.5f;
            }
            if (consumptionValue < maxConsumption)
            {
                consumptionValue += 5f;
            }
        }
        else if (moveSpeed > minSpeed)
        {
            moveSpeed -= 0.1f;
            if (moveSpeed < minSpeed) moveSpeed = minSpeed;
        }
        if (consumptionValue > minConsumption)
        {
            consumptionValue -= 0.25f;
        }
        if (moveSpeed < minSpeed && moveSpeed != 0)
        {
            moveSpeed += 0.1f;
            consumptionValue += 1f;
        }
        speedValue = moveSpeed * 20;
        speedText.text = string.Format("{0:F0}", speedValue) + "km/h";
        consumptionText.text = string.Format("{0:F0}", consumptionValue) + "kWh";
    }

    void Charging()
    {
        if (powerValue <= 52.0f)
        {
            chargingBackgroundImage.SetActive(true);
            chargingText.text = "Charging!";
            powerValue += 6;
        }
        else
        {
            powerValue = 58.0f;
            time += 5f;
            chargingText.text = "Fully charged!";
            CancelInvoke("Charging");
        }
        time += 5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.name.Equals("PowerStation(Clone)"))
        {
            Debug.Log("hit");
            Debug.Log(collision.gameObject.name);
            screenScript.gameOver(powerValue * distanceValue - distanceThreshold - time, false);
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            transform.position = collision.transform.position;
            moveSpeed = 0f;
            consumptionValue = 0f;
            generatePowerStation.respawnTime = 1000f;
            InvokeRepeating("Charging", 0, 1f);
            collision.gameObject.SetActive(false);
        }
    }
}
