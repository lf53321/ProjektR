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
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(cars());
    }

    private void generateCar()
    {
        GameObject gameCar = Instantiate(car) as GameObject;
        gameCar.transform.position = new Vector2(Random.Range(screenBounds.x/2 - 7, screenBounds.x/2 - 2), screenBounds.y);

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
