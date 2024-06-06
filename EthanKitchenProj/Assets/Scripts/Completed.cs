using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Completed : MonoBehaviour
{
    // Start is called before the first frame update
    public Rounds MyPlayer;
    [SerializeField] TextMeshProUGUI completedtext;
    public Slider playercompleted;
 
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        completedtext.text = PlayerStats.Completed.ToString();
        playercompleted.value = Mathf.Floor(MyPlayer.completed)/Mathf.Floor(MyPlayer.completetotal);
    }
}
