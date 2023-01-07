using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePowerStation : MonoBehaviour
{

    public GameObject powerStation;
    private float respawnTime;
    private Vector2 screenBounds;
    public bool prozorZaBateriju = false;

    public GameObject modalPowerStation;
    public GameObject backgroundPanel;

    // Start is called before the first frame update
    void Start()
    {
        respawnTime = Random.Range(10f, 25f);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(cars());
    }

    private void generatePowerStation()
    {
        GameObject pwrStation = Instantiate(powerStation) as GameObject;
        int lucky = Random.Range(0, 10);
        if (lucky <= 5)
        {   
            pwrStation.transform.position = new Vector2(-3f, screenBounds.y);
        } else {
            pwrStation.transform.position = new Vector2(2.95f, screenBounds.y);
            }
    }
    
    public void startIgre(){
            backgroundPanel.SetActive(false);
            modalPowerStation.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked; 
        }

    IEnumerator cars()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            try{
            if(!prozorZaBateriju && !backgroundPanel.activeSelf){
                prozorZaBateriju = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None; 
                backgroundPanel.SetActive(true);
                modalPowerStation.SetActive(true);
            }} catch{
            }

            generatePowerStation();
        }
    }
}
