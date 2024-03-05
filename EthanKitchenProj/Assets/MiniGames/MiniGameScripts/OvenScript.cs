using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvenScript : MonoBehaviour
{
    private float timer = 10f;
    public Returner returner;
    public Slider slider;
    bool completely = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && completely == true)
        {
            completely = false;
            PlayerStats.Errors += 1;
            returner.completed = true;
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && completely == true)
        {
            completely = false;
            returner.completed = true;
        }
        slider.value = 1 - timer/10;
    }
}
