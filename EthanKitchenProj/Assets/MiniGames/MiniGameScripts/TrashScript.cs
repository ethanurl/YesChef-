using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    float completeness = 0;
    public Returner returner;
    public GameObject slicer;
    Transform slt;
    float wcomplete = 0;
    float acomplete = 0;
    float scomplete = 0;
    float dcomplete = 0;
    bool donezo = true;
    // Start is called before the first frame update
    void Start()
    {
        slt = slicer.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wcomplete > 25)
        {wcomplete = 25;}
        if (acomplete > 25)
        {acomplete = 25;}
        if (scomplete > 25)
        {scomplete = 25;}
        if (dcomplete > 25)
        {dcomplete = 25;}
        completeness = wcomplete + scomplete + dcomplete + acomplete;
        Debug.Log(completeness);
        if (Input.GetKey("w"))
        {
            slt.Translate(Vector3.up/150);
            if ((slt.position.x > -2.2 && slt.position.x < -1.8 && slt.position.y >-0.4 && slt.position.y < 2.4) || (slt.position.x > 1.8 && slt.position.x < 2.2 && slt.position.y < 2.4 && slt.position.y > -0.4))
            {
                if (wcomplete < 25)
                {
                    wcomplete += Time.deltaTime*25;
                }
            }
        }
        if (Input.GetKey("s"))
        {
            slt.Translate(Vector3.down/150);
            if ((slt.position.x > -2.2 && slt.position.x < -1.8 && slt.position.y >-0.4 && slt.position.y < 2.4) || (slt.position.x > 1.8 && slt.position.x < 2.2 && slt.position.y < 2.4 && slt.position.y > -0.4))
            {
                if (scomplete < 25)
                {
                    scomplete += Time.deltaTime*25;
                }
            }
        }
        if (Input.GetKey("a"))
        {
            slt.Translate(Vector3.left/150);
            if ((slt.position.x > -2.2 && slt.position.x < 2.2 && slt.position.y >-0.4 && slt.position.y < 0) || (slt.position.x > -2.2 && slt.position.x < 2.2 && slt.position.y < 2.4 && slt.position.y > 2))
            {
                if (acomplete < 25)
                {
                    acomplete += Time.deltaTime*15;
                }
            }
        }
        if (Input.GetKey("d"))
        {
            slt.Translate(Vector3.right/150);
            if ((slt.position.x > -2.2 && slt.position.x < 2.2 && slt.position.y >-0.4 && slt.position.y < 0) || (slt.position.x > -2.2 && slt.position.x < 2.2 && slt.position.y < 2.4 && slt.position.y > 2))
            {
                if (dcomplete < 25)
                {
                    dcomplete += Time.deltaTime*15;
                }
            }
        }
        if (Input.GetKeyDown("e"))
        {
            if (completeness >= 88 && donezo == true)
            {
                returner.completed = true;
                donezo = false;
            }
            if (completeness <88 && donezo == true)
            {
                PlayerStats.Errors += 1;
                returner.completed = true;
                donezo = false;
            }
        }
    }
}