using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
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
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            SlicerTransform = Slicer.GetComponent<RectTransform>();
            if (SlicerTransform.anchoredPosition3D.x<-200&SlicerTransform.anchoredPosition3D.x>-300)
            {
                Debug.Log("Success! :)");
                Zone1.SetActive(false);
                Zone1C = true;
            }
            else if (SlicerTransform.anchoredPosition3D.x<50&SlicerTransform.anchoredPosition3D.x>-50)
            {
                Debug.Log("Success! :)");
                Zone2.SetActive(false);
                Zone2C = true;
            }
            else if (SlicerTransform.anchoredPosition3D.x<300&SlicerTransform.anchoredPosition3D.x>200)
            {

                Debug.Log("Success! :)");
                Zone3.SetActive(false);
                Zone3C = true;
            }
            else
            {
                Debug.Log("Failure :(");
            }
        }
        if ((Zone1C==true)&(Zone2C==true)&(Zone3C==true))
        {
            butcherreturner.completed = true;
        }
    }
}
