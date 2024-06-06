using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExpeditorScript : MonoBehaviour
{
    public Image Plate;
    public Sprite blueplate;
    public Sprite redplate;
    public Image BackgroundCol;
    public Image FillCol;
    public Slider timer;
    public Returner completer;
    public GameObject UI;
    Color BgRed = new Color(140f, 114f, 114f, 255f);
    Color FillRed = new Color(255f, 28f, 0f, 255f);
    Color Bgblue = new Color(0f, 0f, 112f, 255f);
    Color Fillblue = new Color(5f, 50f, 245f, 255f);
    Color BgGrey = new Color(174f, 174f, 174f, 255f);
    Color FillBlack = new Color(0f, 0f, 0f, 255f);
    int totalplates = 0;
    int platecolor = 2;
    int correct = 2;
    bool completely = true;
    public Image foodsprite;
    public Sprite pizza;
    public Sprite meat;
    public Sprite steak;
    public int foodrand;
    // Start is called before the first frame update
    void Start()
    {
        BackgroundCol.color = BgGrey;
        FillCol.color = FillBlack;
        timer.value = 0;
        GetPlate();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer.value < 5)
        {
            timer.value += Time.deltaTime;
        }
    }
    void Update()
    {
        if (platecolor == 1)
        {
            BackgroundCol.color = BgRed;
            FillCol.color = FillRed;
            Plate.sprite = redplate;
            if (Input.GetKeyDown("a"))
            {
                correct = 0;
            }
            if (Input.GetKeyDown("d"))
            {
                correct = 1;
            }
        }
        if (platecolor == 0)
        {
            BackgroundCol.color = Bgblue;
            FillCol.color = Fillblue;
            Plate.sprite = blueplate;
            if (Input.GetKeyDown("d"))
            {
                correct = 0;   
            }
            if (Input.GetKeyDown("a"))
            {
                correct = 1;
            }
        }
        if (correct == 0)
        {
            correct = 2;
            totalplates += 1;
            GetPlate();
        }
        if (correct == 1)
        {
            correct = 2;
            totalplates += 1;
            PlayerStats.Errors += 1;
            GetPlate();
        }
        if (totalplates == 3 && completely == true)
        {
            completely = false;
            Plate.enabled = false;
            UI.SetActive(false);
            completer.completed = true;
        }
    }
    void GetPlate()
    {
        foodrand = Random.Range(0,3);
        if (foodrand == 0)
        {
            foodsprite.sprite = pizza;
        }
        if (foodrand == 1)
        {
            foodsprite.sprite = meat;
        }
        if (foodrand == 2)
        {
            foodsprite.sprite = steak;
        }
        correct = 2;
        timer.value = 0;
        platecolor = Random.Range(0, 2);
    }
}

