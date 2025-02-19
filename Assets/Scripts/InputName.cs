using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InputName : MonoBehaviour
{
    public bool isPlayer;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField.onValueChanged.AddListener(UpdateName);
        
    }

    private void UpdateName(string arg0)
    {
        if (isPlayer)
        {
            SaveControler.Instance.namePlayer = arg0;

        }
        else
        {
            SaveControler.Instance.nameEnemy = arg0;
        }
    }

}
