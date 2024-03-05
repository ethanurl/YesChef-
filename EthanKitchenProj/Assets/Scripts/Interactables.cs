using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Interactables : MonoBehaviour
{
    public Rounds MyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    void OnTriggerEnter(Collider other){
        if (other == MyPlayer.GetComponent<CapsuleCollider>()){
            MyPlayer.child.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other == MyPlayer.GetComponent<CapsuleCollider>()){
            MyPlayer.child.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
