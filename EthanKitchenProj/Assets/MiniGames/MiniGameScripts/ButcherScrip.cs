using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButcherScrip : MonoBehaviour
{
    public GameObject Slicer;
    RectTransform SlicerTransform;
    public GameObject Zone1;
    public GameObject Zone2;
    public GameObject Zone3;
    bool Zone1C = false;
    bool Zone2C = false;
    bool Zone3C = false;
    public Returner butcherreturner;
    private bool completely = true;
    public Image meat1;
    public Image meat2;
    public Image meat3;
    void Start()
    {
        meat1.enabled = false;
        meat2.enabled = false;
        meat3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            SlicerTransform = Slicer.GetComponent<RectTransform>();
            if (SlicerTransform.anchoredPosition3D.x<-200&SlicerTransform.anchoredPosition3D.x>-300)
            {
                Zone1.SetActive(false);
                Zone1C = true;
                meat1.enabled = true;

            }
            else if (SlicerTransform.anchoredPosition3D.x<50&SlicerTransform.anchoredPosition3D.x>-50)
            {
                Zone2.SetActive(false);
                Zone2C = true;
                meat2.enabled = true;
            }
            else if (SlicerTransform.anchoredPosition3D.x<300&SlicerTransform.anchoredPosition3D.x>200)
            {

                Zone3.SetActive(false);
                Zone3C = true;
                meat3.enabled = true;
            }
            else
            {
                PlayerStats.Errors += 1;
            }
        }
        if ((Zone1C==true)&(Zone2C==true)&(Zone3C==true) && completely == true)
        {
            completely = false;
            butcherreturner.completed = true;
        }
    }
}
