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
                        LocalizationManager.Language = "Hrvatski";
                        break;
                    }
                case "EN":
                    {
                        LocalizationManager.Language = "English";
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
                        LocalizationManager.Language = "Hrvatski";
                        break;
                    }
                case "EN":
                    {
                        LocalizationManager.Language = "English";
                        break;
                    }
            }
        }
    }
}
