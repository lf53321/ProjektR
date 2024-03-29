using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ScreenScript : MonoBehaviour
{
    public GameObject screen;

    public TextMeshProUGUI textMeshProUGUI;
    public GameObject modalWindowActive;
    public Text title;

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

    public void gameOver(float score, bool isWin)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(isWin) {
            //TextMeshProUGUI title = screen.transform.Find("GameOverTitle").gameObject.GetComponent<TextMeshProUGUI>();
            
            if(PlayerPrefs.GetString("Language") != "HR")
                title.text = "You won!";
            else
                title.text = "Pobjeda!";

            GameObject trophyLeft = screen.transform.Find("TrophyLeft").gameObject;
            GameObject trophyRight = screen.transform.Find("TrophyRight").gameObject;

            trophyLeft.SetActive(true);
            trophyRight.SetActive(true);
        }   else {
                if(PlayerPrefs.GetString("Language") != "HR")
                    title.text = "You lost!";
                else
                    title.text = "Izgubili ste!";
            }

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
