using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColdPrepScript : MonoBehaviour
{
    List<string> order = new List<string>();
    int newdir;
    int picker = 0;
    public TextMeshProUGUI text;
    public Returner completer;
    public Slider timer;
    bool failure = true;
    bool completely = true;
    // Start is called before the first frame update
    void Start()
    {
        picker = 0;
        order.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.value < timer.maxValue)
        {
            timer.value += Time.deltaTime/7;
        }
        if (timer.value >= timer.maxValue)
        {
            if (failure == true && completely == true)
            {
                completely = false;
                failure = false;
                PlayerStats.Errors += 1;
                completer.completed = true;
            }
        }
        if (order.Count < 10)
        {
            AddDirection();
        }
        if (picker >= order.Count && completely == true)
        {
            completely = false;
            picker = 0;
            completer.completed = true;
        }
        if (picker < order.Count)
        {
            text.text = order[picker];
        }
        if (order.Count == 10)
        {
            if (Input.GetKeyDown(text.text))
            {
                picker += 1;
            }
        }
        
    }
    void AddDirection()
    {
        newdir = UnityEngine.Random.Range(0, 4);
        if (newdir == 0)
        {
            order.Add("w");
        }
        if (newdir == 1)
        {
            order.Add("a");
        }
        if (newdir == 2)
        {
            order.Add("s");
        }
        if (newdir == 3)
        {
            order.Add("d");
        }
    }
}
