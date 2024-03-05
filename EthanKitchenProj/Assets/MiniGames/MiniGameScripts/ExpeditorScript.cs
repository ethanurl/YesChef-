using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExpeditorScript : MonoBehaviour
{
    public GameObject Plate;
    public Material RedMat;
    public Material GreenMat;
    public UnityEngine.UI.Image BackgroundCol;
    public UnityEngine.UI.Image FillCol;
    public Slider timer;
    public TextMeshProUGUI text;
    public Returner completer;
    public GameObject UI;
    Color BgRed = new Color(140f, 114f, 114f, 255f);
    Color FillRed = new Color(255f, 28f, 0f, 255f);
    Color BgGreen = new Color(121f, 149f, 112f, 255f);
    Color FillGreen = new Color(5f, 241f, 0f, 255f);
    Color BgGrey = new Color(174f, 174f, 174f, 255f);
    Color FillBlack = new Color(0f, 0f, 0f, 255f);
    int totalplates = 0;
    int platecolor = 2;
    int correct = 2;
    bool completely = true;
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
            Plate.GetComponent<MeshRenderer>().material = RedMat;
            text.text = "Press A!";
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
            BackgroundCol.color = BgGreen;
            FillCol.color = FillGreen;
            Plate.GetComponent<MeshRenderer>().material = GreenMat;
            text.text = "Press D!";
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
            Plate.SetActive(false);
            UI.SetActive(false);
            completer.completed = true;
        }
    }
    void GetPlate()
    {
        correct = 2;
        timer.value = 0;
        platecolor = Random.Range(0, 2);
    }
}

