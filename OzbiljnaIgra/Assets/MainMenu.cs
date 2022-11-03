using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        // the app will not close if this function is invoked inside Unity editor
        Debug.Log("QUIT!"); // testing if QuitGame is invoked
        Application.Quit();
    }

    public void LoadGame() {
        // TODO implement
        Debug.Log("Not yet implemented...");
    }
}
