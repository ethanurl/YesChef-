using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Rounds : MonoBehaviour
{
    public Material redcarpet;
    public int round = 1;
    public int roundtimer = 5;
    public int sceneswap = -1;
    public GameObject[] newrandoms;
    public GameObject changer;
    public GameObject changerchild;
    public GameObject child;
    public Transition transition;
    public Timer timer;
    public Canvas pausemenu;
    public int errors = 0;
    public int errorstotal = 5;
    public int completed = 0;
    public int completetotal = 10;
    private Material currmat;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.Completed == 0)
        {
            PlayerStats.Time = 90;
        }
        if (newrandoms == null)
        Debug.Log("ok");
        newrandoms = GameObject.FindGameObjectsWithTag("Interactable");
        child = gameObject.transform.GetChild(0).gameObject;
        child.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        errors = PlayerStats.Errors;
        completed = PlayerStats.Completed;
        timer.elapsedtime = PlayerStats.Time;
        //These are the win/loss condition. 
        //If errors is whatever the total is, the player loses!
        //If completed, the player wins.
        if (errors == errorstotal)
        {
            transition.newscene = 17;
            PlayerStats.Errors = 0;
            PlayerStats.Completehold = 0;
            PlayerStats.Completed = 0;
            PlayerStats.Time = 0;
        }
        if (completed == completetotal)
        {
            transition.newscene = 18;
            PlayerStats.Errors = 0;
            PlayerStats.Completehold = 0;
            PlayerStats.Completed = 0;
            PlayerStats.Time = 0;
        }
        if (Time.realtimeSinceStartupAsDouble/round > roundtimer)
        {
            if (changer)
            {
                changer.GetComponent<MeshRenderer>().material = currmat;
                changerchild.GetComponent<BoxCollider>().enabled = false;
                child.GetComponent<MeshRenderer>().enabled = false;
            }
            int rand = UnityEngine.Random.Range (0, newrandoms.Length);
            changer = newrandoms[rand];
            sceneswap = rand + 1;
            changerchild = changer.gameObject.transform.GetChild(0).gameObject;
            currmat = changer.GetComponent<MeshRenderer>().material;
            changer.GetComponent<MeshRenderer>().material = redcarpet;
            changerchild.GetComponent<BoxCollider>().enabled = true;
            round += 1;
        }
        if (child.GetComponent<MeshRenderer>().enabled == true){
            if (Input.GetKeyDown("e"))
                {
                    child.GetComponent<MeshRenderer>().enabled =  false;
                    PlayerStats.Errors = errors;
                    PlayerStats.Completehold = completed;
                    transition.newscene = sceneswap;
                }
        }
        if (Input.GetKeyDown("escape")){
            PlayerStats.Errors = errors;
            PlayerStats.Completehold = completed;
            Time.timeScale = 0;

        }
    }
}
/*IF LEVELS GET TOO BIG THIS IS THE LEVEL LOADER
        if (child.GetComponent<MeshRenderer>().enabled == true){
           if (Input.GetKeyDown("e")){
                StartCoroutine(LoadGameScene());
            };
        };
    }
    
    IEnumerator LoadGameScene(){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Assets/Scenes/Expeditor.unity");
        while (!asyncLoad.isDone){
            yield return null;*/

