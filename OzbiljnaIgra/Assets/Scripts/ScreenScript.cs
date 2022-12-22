using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScreenScript : MonoBehaviour
{
    public GameObject screen;

    public TextMeshProUGUI textMeshProUGUI;
    public GameObject modalWindowActive;

    // Start is called before the first frame update
    void Start()
    {
        if(!modalWindowActive.activeSelf || (modalWindowActive == null)){
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.activeInHierarchy)
        //{
        //    Cursor.visible = true;
          //  Cursor.lockState = CursorLockMode.None;
        //}
    }

    public void gameOver(float score)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        screen.SetActive(true);
        textMeshProUGUI.text = score.ToString("0.0").Replace(',','.');
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // The method opens the main menu rather than quitting the application.
    public void quit()
    {
        string menu = "Menu";
        SceneManager.LoadScene(menu);
    }

    public void next() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
