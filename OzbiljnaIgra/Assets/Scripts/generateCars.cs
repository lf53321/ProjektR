using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateCars : MonoBehaviour
{

    public GameObject car;
    public float respawnTime = 1f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("speedUp", 0f, 10f);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(cars());
    }

    private void generateCar()
    {
        GameObject gameCar = Instantiate(car) as GameObject;
        gameCar.transform.position = new Vector2(Random.Range(-3, 2.95f), screenBounds.y);

    }

    private void speedUp()
    {
        if (respawnTime > 0.3f)
        {
            respawnTime -= 0.10f;
        }
    }

    IEnumerator cars()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            generateCar();
        }
    }
}
