using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditorScript : MonoBehaviour
{
    public GameObject plate1;
    public GameObject plate2;
    public GameObject plate3;
    GameObject currplate;
    public Animator platesanim;
    // Start is called before the first frame update
    void Start()
    {
        int plate1color = Random.Range (0, 1);
        if (plate1color == 1)
        {
            platesanim.SetTrigger("RedPlate");
        }
        if (plate1color == 0)
        {
            platesanim.SetTrigger("GreenPlate");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Plate2()
    {
        int plate2color = Random.Range(0, 1);
        if (plate2color == 1)
        {
            platesanim.SetTrigger("RedPlate");
        }
        if (plate2color == 0)
        {
            platesanim.SetTrigger("GreenPlate");
        }
    }
    void Plate3()
    {
        int plate3color = Random.Range(0, 1);
        if (plate3color == 1)
        {
            platesanim.SetTrigger("RedPlate");
        }
        if (plate3color == 0)
        {
            platesanim.SetTrigger("GreenPlate");
        }
    }
}
