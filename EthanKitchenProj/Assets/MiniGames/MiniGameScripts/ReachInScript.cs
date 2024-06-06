 using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ReachInScript : MonoBehaviour
{
    private GameObject UIchild;
    public Returner returner;
    public Image changer;
    bool completely = true;
    // Start is called before the first frame update
    void Start()
    {
        UIchild = this.transform.GetChild(Random.Range(0,20)).gameObject;
        Image yomamasprite = UIchild.GetComponent<Image>();
        changer.sprite = yomamasprite.sprite;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("e"))
        {
            if (EventSystem.current.currentSelectedGameObject == UIchild && completely == true)
            {
                completely = false;
                returner.completed = true;
            }
            if (EventSystem.current.currentSelectedGameObject != UIchild && completely == true)
            {
                completely = false;
                PlayerStats.Errors += 1;
                returner.completed = true;
            }
        }
        
    }
}
