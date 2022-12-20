using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    [SerializeField] Slider volumeSlider;

    public AudioMixer audioMixer;

    private string city = "CityLevelButton";
    private string country = "CountrysideLevelButton";
    private string snow = "SnowLevelButton";
    private string quiz = "QuizLevelButton";

    private int citySceneNumber = 1;
    private int countrySceneNumber = 2;
    private int snowSceneNumber = 3;
    private int quizSceneNumber = 4;

    void Start() {
        // set default volume value if there is none in the PlayerPrefs
        if(!PlayerPrefs.HasKey("VolumeValue")) {
            PlayerPrefs.SetFloat("VolumeValue", -40);
            LoadVolume();
        } else {
            LoadVolume();
        }
    }

    public void PlayGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        // the app will not close if this function is invoked inside Unity editor
        Debug.Log("QUIT!"); // testing if QuitGame is invoked
        Application.Quit();
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
        SaveVolume();
    }

    void LoadVolume() {
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeValue");
    }

    void SaveVolume() {
        PlayerPrefs.SetFloat("VolumeValue", volumeSlider.value);
    }

    public void LoadGame() {
        
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(buttonName);

        if (buttonName == city) {
            SceneManager.LoadScene(citySceneNumber);

        } else if (buttonName == country) {
            SceneManager.LoadScene(countrySceneNumber);

        } else if (buttonName == snow) {
            SceneManager.LoadScene(snowSceneNumber);
        
        } else if (buttonName == quiz) {
            SceneManager.LoadScene(quizSceneNumber);
        }
    }
}
