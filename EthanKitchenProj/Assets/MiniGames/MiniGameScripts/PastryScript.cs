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
    public Image pizza;
    public Sprite pizza2;
    public Sprite pizza3;
    public Sprite pizza4;
    public Sprite pizzafin;
    public RectTransform roller;
    public Image arrow;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(("topval", topvalreached.ToString(), "\n", "botval", botvalreached.ToString()));
        slider.value = value;
        text.text = ("Roll over the pizza!" + "\n" + (5 - valsreached)).ToString();
        if (topvalreached == false)
        {
            if (value >= topval)
            {
                topval += 0.1f;
                valsreached += 1;
                topvalreached = true;
                botvalreached = false;
                arrow.rectTransform.eulerAngles = new Vector3(0, 0, 0);
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
                arrow.rectTransform.eulerAngles = new Vector3(0, 0, 180);
            }
        }
        
        if (Input.GetKey("w"))
        {
            value += Time.deltaTime/3;
            roller.Translate(Vector3.up);
        }
        if (Input.GetKey("s"))
        {
            value -= Time.deltaTime/3;
            roller.Translate(Vector3.down);
        }
        if (valsreached == 5 & reacher == true)
        {
            reacher = false;
            text.text = "Done!";
            returner.completed = true;
        }
        if (valsreached == 1)
        {
            pizza.sprite = pizza2;
        }
        if (valsreached == 2)
        {
            pizza.sprite = pizza3;
        }
        if (valsreached == 3)
        {
            pizza.sprite = pizza4;
        }
        if (valsreached == 4)
        {
            pizza.sprite = pizzafin;
        }
    }
}
