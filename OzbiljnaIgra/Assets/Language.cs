using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;

public class Language : MonoBehaviour
{
    private void Awake() {

        LocalizationManager.Read();

    
        LocalizationManager.Language = "Hrvatski";

    }
}
