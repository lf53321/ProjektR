using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;

public class Language : MonoBehaviour
{
    private void Awake() {

        LocalizationManager.Read();

        if (PlayerPrefs.HasKey("Language")){
            switch (PlayerPrefs.GetString("Language"))
            {
                case "HR":
                    {
                        if(PlayerPrefs.GetFloat("Simplified") != 1){
                            LocalizationManager.Language = "Hrvatski";
                            break;}
                        
                        LocalizationManager.Language = "Hrvatski.Simple";
                        break;
                    }
                case "EN":
                    {   
                        if(PlayerPrefs.GetFloat("Simplified") != 1){
                                LocalizationManager.Language = "English";
                                break;}

                        LocalizationManager.Language = "English.Simple";
                        break;
                    }
            }
        }
    }

    public static void switchLang()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            switch (PlayerPrefs.GetString("Language"))
            {
                case "HR":
                    {
                        if(PlayerPrefs.GetFloat("Simplified") != 1){
                            LocalizationManager.Language = "Hrvatski";
                            break;}
                        
                        LocalizationManager.Language = "Hrvatski.Simple";
                        break;
                    }
                case "EN":
                    {   
                        if(PlayerPrefs.GetFloat("Simplified") != 1){
                                LocalizationManager.Language = "English";
                                break;}

                        LocalizationManager.Language = "English.Simple";
                        break;
                    }
            }
        }
    }
}
