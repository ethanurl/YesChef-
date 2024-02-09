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
    public Material emptymat;
    public int round = 1;
    public int roundtimer = 5;
    public int sceneswap = -1;
    public GameObject[] newrandoms;
    public GameObject changer;
    public GameObject changerchild;
    public GameObject child;
    public Transition transition;
    public Timer timer;
    public int errors = 0;
    public int errorstotal = 5;
    public int completed = 0;
    public int completetotal = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (newrandoms == null)
        Debug.Log("ok");
        newrandoms = GameObject.FindGameObjectsWithTag("Interactable");
        child = gameObject.transform.GetChild(0).gameObject;
        child.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartupAsDouble/round > roundtimer)
        {
            if (PlayerStats.Completehold != PlayerStats.Completed){
                    PlayerStats.Completed = PlayerStats.Completehold;
                }
            if (changer)
            {
                errors = PlayerStats.Errors;
                completed = PlayerStats.Completed;
                timer.elapsedtime = PlayerStats.Time;
                changer.GetComponent<MeshRenderer>().material = emptymat;
                changerchild.GetComponent<BoxCollider>().enabled = false;
                child.GetComponent<MeshRenderer>().enabled = false;
            }
            int rand = UnityEngine.Random.Range (0, newrandoms.Length);
            changer = newrandoms[rand];
            sceneswap = rand + 1;
            changerchild = changer.gameObject.transform.GetChild(0).gameObject;
            changer.GetComponent<MeshRenderer>().material = redcarpet;
            changerchild.GetComponent<BoxCollider>().enabled = true;
            round += 1;
        }
        if (child.GetComponent<MeshRenderer>().enabled == true){
            if (Input.GetKeyDown("e"))
                {
                    completed += 1;
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
                    else
                    {
                        child.GetComponent<MeshRenderer>().enabled =  false;
                        PlayerStats.Errors = errors;
                        PlayerStats.Completehold = completed;
                        transition.newscene = sceneswap;
                    }
                }
        }
        if (Input.GetKeyDown("escape")){
            PlayerStats.Errors = errors;
            PlayerStats.Completehold = completed;
            transition.newscene = 14;
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

