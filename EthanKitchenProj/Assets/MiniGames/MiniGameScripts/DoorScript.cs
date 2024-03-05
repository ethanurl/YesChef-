using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public Slider slider;
    public Returner completer;
    private bool direction = true;
    private float up;
    private float down;
    public bool donezo = true;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        slider.enabled = false;
        slider.value = 0;
        up = Random.Range(0f, 20f);
        down = Random.Range(0f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0.98)
        {
            direction = false;
            down = Random.Range(0f, 20f);
        }
        if (slider.value < 0.02)
        {
            direction = true;
            up = Random.Range(0f, 20f);
        }
        if (direction == true)
        {
            slider.value += Time.deltaTime/10 * up;
        }   
        if (direction == false)
        {
            slider.value -= Time.deltaTime/10 * down;
        }
        if (slider.value < 0.15f || slider.value > 0.85f)
        {
            image.color = new Color32(0,255,0,100);
            if (Input.GetKeyDown("e") & donezo == true)
            {
                donezo = false;
                completer.completed = true;
            }
        }
        if (slider.value > 0.15f && slider.value < 0.85f)
        {
            image.color = new Color32(255,0,0,100);
            if (Input.GetKeyDown("e") & donezo == true)
            {
                PlayerStats.Errors += 1;

                donezo = false;
                completer.completed = true;
            }
        }
        
    }
}
