using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Movement : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerSprite;
    public GameObject looker;
    public float target;
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
        //This controls how the player rotates
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            looker.transform.position = new Vector3(Player.transform.position.x - Input.GetAxis("Horizontal"), -100, Player.transform.position.z - Input.GetAxis("Vertical"));
        }
        if (Input.anyKey == false)
        {
            looker.transform.position = Player.transform.position;
        }
        PlayerSprite.transform.LookAt(looker.transform);

    }
}
