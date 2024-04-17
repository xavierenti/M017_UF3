using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Loguin_Screen : MonoBehaviour
{
    [SerializeField] private Button loguinButton;
    [SerializeField] private TMP_InputField loguinText;
    [SerializeField] private TMP_InputField passwordText;

    private void Awake()
    {
        loguinButton.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        Networck_Manager._NETWORCK_MANAGER.ConnectToServer(loguinText.ToString(), passwordText.ToString());
    }
}
