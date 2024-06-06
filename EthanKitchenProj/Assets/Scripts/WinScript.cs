using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "You finished your shift and helped " + PlayerStats.Completed + " stations!";
        PlayerStats.Completed = 0;
        PlayerStats.Completehold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
