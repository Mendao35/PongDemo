using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuControler : MonoBehaviour
{

    public TextMeshProUGUI uiWinner;

    // Start is called before the first frame update
    void Start()
    {
        SaveControler.Instance.Reset();
        string lastWinner = SaveControler.Instance.GetLastWinner();

        if(lastWinner != "")
        {
            uiWinner.text = "Ultimo vencedor. " + lastWinner;
        }
        else
        {
            uiWinner.text = "";
        }
        
    }

    
}
