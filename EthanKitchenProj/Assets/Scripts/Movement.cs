using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Movement : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody Forced = Player.GetComponent<Rigidbody>();
        ///THIS IS PLAYER MOVEMENT
        Forced.AddForce(Vector3.forward * Input.GetAxis("Vertical"));
        Forced.AddForce(Vector3.right * Input.GetAxis("Horizontal"));
    }
}
