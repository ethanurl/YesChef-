using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI timerText;
    public float elapsedtime;
    public int currentcompleted = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.Completed > currentcompleted){
            currentcompleted = PlayerStats.Completed;
            elapsedtime = PlayerStats.Time + 0.5f;
        };
        if (Input.GetKeyDown("escape")){
            elapsedtime = PlayerStats.Time + 0.05f;
        }
        elapsedtime -= Time.deltaTime;
        PlayerStats.Time = elapsedtime;
        int minutes = Mathf.FloorToInt(elapsedtime / 60);
        int seconds = Mathf.FloorToInt(elapsedtime % 60);
        timerText.text=string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
