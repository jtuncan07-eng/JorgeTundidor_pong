using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class game_manager : MonoBehaviour
{
    public int PuntosP1 = 0;
    public int PuntosP2 = 0;
    public string text;
    public TextMeshProUGUI marc;
    public GameObject WinPanel;

    void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        WinMenu();
        text = PuntosP1 + "||" + PuntosP2;
        Debug.Log("sabias que vaporeon");
        marc.text = text;
    }
    public void WinMenu()
    {
        if (PuntosP1 == 4 || PuntosP2 == 4)
        {
            WinPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
