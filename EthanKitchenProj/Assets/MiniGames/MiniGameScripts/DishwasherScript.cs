using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DishwasherScript : MonoBehaviour
{
     List<string> order = new List<string>();
    int newdir;
    int picker = 0;
    public TextMeshProUGUI text;
    public Returner completer;
    public int dishes;
    public Slider timer;
    bool failure = true;
    bool completely = true;
    public Animator spongeanim;
    public Image plate;
    public Sprite cleanplate;
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
        if (order.Count < 8)
        {
            AddDirection();
        }
        if (picker >= order.Count)
        {
            picker = 0;
            dishes += 1;
            order.Clear();
        }
        if (order.Count == 8)
        {
            text.text = order[picker];
            if (Input.GetKeyDown(text.text))
            {
                picker += 1;
                spongeanim.SetInteger("State", 1);
            }
            else
            {
                spongeanim.SetInteger("State", 2);
            }
            if (Input.GetKeyDown("w"))
            {
                spongeanim.SetFloat("Blend", 0.1f);
            }
            if (Input.GetKeyDown("a"))
            {
                spongeanim.SetFloat("Blend", 0f);
            }
            if (Input.GetKeyDown("s"))
            {
                spongeanim.SetFloat("Blend", 0.2f);
            }
            if (Input.GetKeyDown("d"))
            {
                spongeanim.SetFloat("Blend", 0.3f);
            }
        }
        if (dishes == 3 && completely == true)
        {
            plate.sprite = cleanplate;
            completely = false;
            completer.completed = true;
        }
        
    }
    void AddDirection()
    {
        order.Add("w");
        order.Add("a");
        order.Add("s");
        order.Add("d");
        order.Add("w");
        order.Add("a");
        order.Add("s");
        order.Add("d");
    }
}
