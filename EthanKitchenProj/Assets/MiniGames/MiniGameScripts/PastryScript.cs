using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PastryScript : MonoBehaviour
{
    private float value = 0.5f;
    public Slider slider;
    private float topval = 0.75f;
    private float botval = 0.25f;
    private bool botvalreached = false;
    private bool topvalreached = false;
    private int valsreached = 0;
    private bool reacher = true;
    public TextMeshProUGUI text;
    public Returner returner;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(("topval", topvalreached.ToString(), "\n", "botval", botvalreached.ToString()));
        slider.value = value;
        text.text = (5 - valsreached).ToString();
        if (topvalreached == false)
        {
            if (value >= topval)
            {
                topval += 0.1f;
                valsreached += 1;
                topvalreached = true;
                botvalreached = false;
            }
        }
        if (botvalreached == false)
        {
            if (value <= botval)
            {
                botval -= 0.1f;
                valsreached += 1;
                botvalreached = true;
                topvalreached = false;
            }
        }
        
        if (Input.GetKey("w"))
        {
            value += Time.deltaTime/3;
        }
        if (Input.GetKey("s"))
        {
            value -= Time.deltaTime/3;
        }
        if (valsreached == 5 & reacher == true)
        {
            reacher = false;
            text.text = "Done!";
            returner.completed = true;
        }
    }
}
