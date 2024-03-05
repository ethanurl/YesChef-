using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HotPrepScript : MonoBehaviour
{
    int i1;
    int i2;
    int i3;
    int i4;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public Returner completer;
    private bool donezo = true;

    // Start is called before the first frame update
    void Start()
    {
        i1 = Random.Range(1, 6);
        i2 = Random.Range(1, 6);
        i3 = Random.Range(1, 6);
        i4 = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = ("W", i1).ToString();
        text2.text = ("A", i2).ToString();
        text3.text = ("S", i3).ToString();
        text4.text = ("D", i4).ToString();
        if (Input.GetKeyDown("w"))
        {
            i1 -= 1;
        }
        if (Input.GetKeyDown("a"))
        {
            i2 -= 1;
        }
        if (Input.GetKeyDown("s"))
        {
            i3 -= 1;
        }
        if (Input.GetKeyDown("d"))
        {
            i4 -= 1;
        }
        if (Input.GetKeyDown("e") && donezo == true)
        {
            if (i1 == 0 && i2 == 0 && i3 == 0 && i4 == 0)
            {
                donezo = false;
                completer.completed = true;
            }
            else 
            {
                donezo = false;
                PlayerStats.Errors += 1;
                completer.completed = true;
            }
        }
    }
}
