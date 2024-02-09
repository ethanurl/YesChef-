using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ///THIS IS PLAYER MOVEMENT
        transform.Translate(transform.forward.normalized * Input.GetAxis("Vertical")/6);
        transform.Translate(transform.right.normalized * Input.GetAxis("Horizontal")/6);
    }
}
