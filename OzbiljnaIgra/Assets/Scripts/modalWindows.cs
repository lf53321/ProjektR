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

    public void ucenjeBaterija(){
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
        backgroundPanel.SetActive(true);
        modalPowerStation.SetActive(true);
    }

}
