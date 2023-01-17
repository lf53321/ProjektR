using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modalWindows : MonoBehaviour
{
    public GameObject backgroundPanel;
    public GameObject modalIntroduction;
    public GameObject modalStatistics;
    public GameObject modalGoal;
    public GameObject modalPowerStation;
    public GameObject modal2Intro;
    public GameObject modal2Gameplay;
    public GameObject modal3Gameplay;


     public void pokreniIntroduction(){
        backgroundPanel.SetActive(true);
        modalIntroduction.SetActive(true);
    }

    public void pokreniStats(){
        modalIntroduction.SetActive(false);
        modalStatistics.SetActive(true);
    }

    public void pokreniGoal(){
        modalStatistics.SetActive(false);
        modalGoal.SetActive(true);
    }

    public void startIgre(){
        backgroundPanel.SetActive(false);
        modalGoal.SetActive(false);
        modalPowerStation.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    public void pokreni2Gameplay(){
        modal2Intro.SetActive(false);
        modal2Gameplay.SetActive(true);
    }

    public void start2Igre(){
        backgroundPanel.SetActive(false);
        modal2Gameplay.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    public void start3Igre(){
        backgroundPanel.SetActive(false);
        modal3Gameplay.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    public void ucenjeBaterija(){
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
        backgroundPanel.SetActive(true);
        modalPowerStation.SetActive(true);
    }

}
