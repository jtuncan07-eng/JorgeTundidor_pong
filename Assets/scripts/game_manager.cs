using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public int PuntosP1 = 0;
    public int PuntosP2 = 0;
    public string text;
    public TextMeshProUGUI marc;
        
    void Start()
    {  

    }

    private void Update()
    {
        text = PuntosP1 + "||" + PuntosP2;
        Debug.Log("sabias que vaporeon");
        marc.text = text;
    }

}
