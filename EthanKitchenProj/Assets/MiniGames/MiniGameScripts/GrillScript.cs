using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrillScript : MonoBehaviour
{
    public Image leftim;
    public Image rightim;
    public Image leftmeat;
    public Image rightmeat;
    public Sprite donemeat;
    public Sprite supadonemeat;
    public Slider leftsl;
    public Slider rightsl;
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
        leftim.enabled = false;
        rightim.enabled = false;
        leftsl.value = 0;
        rightsl.value = 0;
        GetVals();
    }

    // Update is called once per frame
    void Update()
    {
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
            leftim.enabled = true;
            leftmeat.sprite = donemeat;
        }
        if (rightsl.value >= rightlowval && rightsl.value <= righthighval)
        {
            rightim.enabled = true;
            rightmeat.sprite = donemeat;
        }
        if (leftsl.value >= lefthighval)
        {
            leftim.enabled = false;
            leftmeat.sprite = supadonemeat;
        }
        if (rightsl.value >= righthighval)
        {
            rightim.enabled = false;
            rightmeat.sprite = supadonemeat;
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
            leftlowval = Random.Range(0.4f, 0.65f);
        }
        if (lefthighval == 0)
        {
            lefthighval = Random.Range(0.65f, 0.8f);
        }
        if (rightlowval == 0)
        {
            rightlowval = Random.Range(0.4f, 0.65f);
        }
        if (righthighval == 0)
        {
            righthighval = Random.Range(0.65f, 0.8f);
        }
    }
}
