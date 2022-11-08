using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField] Slider volumeSlider;

    public AudioMixer audioMixer;

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

    public void LoadGame() {
        // TODO implement
        Debug.Log("Not yet implemented...");
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
}
