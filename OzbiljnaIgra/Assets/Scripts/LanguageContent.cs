using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageContent : MonoBehaviour
{
    public TextMeshProUGUI introductionContent;
    public TextMeshProUGUI statisticsContent;
    public TextMeshProUGUI goalContent;

    public TextMeshProUGUI chargingStationContent;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Language") && PlayerPrefs.GetString("Language") == "HR") {
            introductionContent.SetText("Dobrodošli u Voltaway!\n\n U ovoj ozbiljnoj igri potrudit ćemo se naučiti vas osnovne koncepte o električnim vozilima (poznatim kao EV).");
            statisticsContent.SetText("Prvo nešto o vašoj statistici.\n\n Statistiku možete vidjeti na desnoj strani ekrana sljedećim redoslijedom:\n\n • vrijeme - trenutno vrijeme koje je proteklo\n • baterija - vaša razina baterije\n • udaljenost - udaljenost do cilja\n • brzina - koliko brzo se krećete\n • potrošnja - koliko baterije trošite");
            goalContent.SetText("Cilj igre je jednostavan. Vi ste vozač u električnom vozilu (EV).\n\n Želite proći zadanu udaljenost u što kraćem vremenskom roku");
            chargingStationContent.SetText("Ovo je stanica za punjenje. Ona će vam napuniti bateriju ali morat ćete potrošiti određeno vrijeme.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
