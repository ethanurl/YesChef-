using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrillScript : MonoBehaviour
{
    public Image leftim;
    public Image rightim;
    public Slider leftsl;
    public Slider rightsl;
    public Material emptymat;
    public Material redmat;
    public Material greenmat;
    public Returner returner;
    private float leftval;
    private float rightval;
    private float leftlowval;
    private float lefthighval;
    private float rightlowval;
    private float righthighval;
    bool completely = true;

    // Start is called before the first frame update
    void Start()
    {
        leftim.material = emptymat;
        rightim.material = emptymat;
        leftsl.value = 0;
        rightsl.value = 0;
        GetVals();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((leftsl.value, "/n", rightsl.value));
        if (Input.GetKey("e"))
        {
            rightsl.value += Time.deltaTime/5;
        }
        if (Input.GetKey("q"))
        {
            leftsl.value += Time.deltaTime/5;
        }
        if (leftsl.value >= leftlowval && leftsl.value <= lefthighval)
        {
            leftim.material = greenmat;
        }
        if (rightsl.value >= rightlowval && rightsl.value <= righthighval)
        {
            rightim.material = greenmat;
        }
        if (leftsl.value >= lefthighval)
        {
            leftim.material = redmat;
        }
        if (rightsl.value >= righthighval)
        {
            rightim.material = redmat;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (leftsl.value >= leftlowval && leftsl.value <= lefthighval && rightsl.value >= rightlowval && rightsl.value <= righthighval && completely == true)
            {
                completely = false;
                returner.completed = true;
            }
            else if (completely == true)
            {
                completely = false;
                PlayerStats.Errors += 1;
                returner.completed = true;
            }
        }


    }
    void GetVals()
    {
        if (leftlowval == 0)
        {
            leftlowval = Random.Range(0.4f, 0.7f);
        }
        if (lefthighval == 0)
        {
            lefthighval = Random.Range(0.75f, 1.0f);
        }
        if (rightlowval == 0)
        {
            rightlowval = Random.Range(0.4f, 0.7f);
        }
        if (righthighval == 0)
        {
            righthighval = Random.Range(0.75f, 1.0f);
        }
    }
}
