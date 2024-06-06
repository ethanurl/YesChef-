using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

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
    public int completetotal = 100;
    private Material currmat;
    public GameObject trashcan;
    public GameObject trashcanlined;
    public GameObject grill;
    public GameObject grillred;
    public GameObject expeditor;
    public GameObject expeditorfull;
    public GameObject fryer;
    public GameObject fryerfull;
    public GameObject dishwasher;
    public GameObject dishwasherfull;
    public GameObject door;
    public GameObject dooropen;
    public GameObject reachin;
    public GameObject reachinneed;
    public GameObject oven;
    public GameObject ovencheck;
    public GameObject coldprep;
    public GameObject coldprephelp;
    public GameObject hotprep;
    public GameObject hotprephelp;
    public GameObject pastry;
    public GameObject pastryhelp;
    public GameObject butcher;
    public GameObject butcherhelp;
    public AudioSource ding;
    private bool pauser = true;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.Completed == 0)
        {
            PlayerStats.Time = 90;
            PlayerStats.PlayerX = -10.81f;
            PlayerStats.PlayerZ = -7.21f;
        }
        transform.position = new Vector3 (PlayerStats.PlayerX, 1, PlayerStats.PlayerZ);
        if (newrandoms == null)
        Debug.Log("ok");
        newrandoms = GameObject.FindGameObjectsWithTag("Interactable");
        child = gameObject.transform.GetChild(0).gameObject;
        child.GetComponent<MeshRenderer>().enabled = false;
        //this code is mostly enabling/disabling objects
        trashcan.SetActive(false);
        trashcanlined.SetActive(true);
        grill.SetActive(true);
        grillred.SetActive(false);
        expeditor.SetActive(true);
        expeditorfull.SetActive(false);
        fryer.SetActive(true);
        fryerfull.SetActive(false);
        dishwasher.SetActive(true);
        dishwasherfull.SetActive(false);
        door.SetActive(true);
        dooropen.SetActive(false);
        reachin.SetActive(true);
        reachinneed.SetActive(false);
        oven.SetActive(true);
        ovencheck.SetActive(false);
        coldprep.SetActive(true);
        coldprephelp.SetActive(false);
        hotprep.SetActive(true);
        hotprephelp.SetActive(false);
        pastry.SetActive(true);
        pastryhelp.SetActive(false);
        butcher.SetActive(true);
        butcherhelp.SetActive(false);
        pausemenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (completed != PlayerStats.Completed)
        {
            ding.Play();
        }
        errors = PlayerStats.Errors;
        completed = PlayerStats.Completed;
        timer.elapsedtime = PlayerStats.Time;
        //These are the win/loss condition. 
        //If errors is whatever the total is, the player loses!
        //If completed, the player wins.
        if (errors >= errorstotal)
        {
            transition.newscene = 17;
        }
        if (completed == completetotal)
        {
            transition.newscene = 18;
            PlayerStats.Errors = 0;
            PlayerStats.Time = 0;
        }
        if (Time.realtimeSinceStartup/round > roundtimer)
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
        //This is all the setactive for the sprites with the rounds
        //125 lines because idk how to not hard code everything
        if (changer)
        {
            if (changer.name == "Trash")
            {
                trashcanlined.SetActive(true);
                trashcan.SetActive(false);
            }
            if (changer.name != "Trash")
            {
                trashcanlined.SetActive(false);
                trashcan.SetActive(true);
            }
            if (changer.name == "Grill")
            {
                grill.SetActive(false);
                grillred.SetActive(true);
            }
            if (changer.name != "Grill")
            {
                grill.SetActive(true);
                grillred.SetActive(false);   
            }
            if (changer.name == "Expeditor")
            {
                expeditor.SetActive(false);
                expeditorfull.SetActive(true);   
            }
            if (changer.name != "Expeditor")
            {
                expeditor.SetActive(true);
                expeditorfull.SetActive(false);
            }
            if (changer.name == "Fryer")
            {
                fryer.SetActive(false);
                fryerfull.SetActive(true);
            }
            if (changer.name != "Fryer")
            {
                fryer.SetActive(true);
                fryerfull.SetActive(false);
            }
            if (changer.name == "Dishwasher")
            {
                dishwasher.SetActive(false);
                dishwasherfull.SetActive(true);
            }
            if (changer.name != "Dishwasher")
            {
                dishwasher.SetActive(true);
                dishwasherfull.SetActive(false);
            }
            if (changer.name == "Door")
            {
                door.SetActive(false);
                dooropen.SetActive(true);
            }
            if (changer.name != "Door")
            {
                door.SetActive(true);
                dooropen.SetActive(false);
            }
            if (changer.name == "Reach-In")
            {
                reachin.SetActive(false);
                reachinneed.SetActive(true);
            }
            if (changer.name != "Reach-In")
            {
                reachin.SetActive(true);
                reachinneed.SetActive(false);
            }
            if (changer.name == "Oven")
            {
                oven.SetActive(false);
                ovencheck.SetActive(true);
            }
            if (changer.name != "Oven")
            {
                oven.SetActive(true);
                ovencheck.SetActive(false);
            }
            if (changer.name == "Cold Prep")
            {
                coldprep.SetActive(false);
                coldprephelp.SetActive(true);
            }
            if (changer.name != "Cold Prep")
            {
                coldprep.SetActive(true);
                coldprephelp.SetActive(false);
            }
            if (changer.name == "Hot Prep")
            {
                hotprep.SetActive(false);
                hotprephelp.SetActive(true);
            }
            if (changer.name != "Hot Prep")
            {
                hotprep.SetActive(true);
                hotprephelp.SetActive(false);
            }
            if (changer.name == "Pastry")
            {
                pastry.SetActive(false);
                pastryhelp.SetActive(true);
            }
            if (changer.name != "Pastry")
            {
                pastry.SetActive(true);
                pastryhelp.SetActive(false);
            }
            if (changer.name == "Butcher")
            {
                butcher.SetActive(false);
                butcherhelp.SetActive(true);
            }
            if (changer.name != "Butcher")
            {
                butcher.SetActive(true);
                butcherhelp.SetActive(false);
            }

        }
        if (child.GetComponent<MeshRenderer>().enabled == true){
            if (Input.GetKeyDown("e"))
                {
                    child.GetComponent<MeshRenderer>().enabled =  false;
                    PlayerStats.Errors = errors;
                    PlayerStats.Completehold = completed;
                    PlayerStats.PlayerX = transform.position.x;
                    PlayerStats.PlayerZ = transform.position.z;
                    transition.newscene = sceneswap;
                }
        }
        if (Input.GetKeyDown("escape") && pauser == true)
        {
            Pause();
        }
        if (Input.GetKeyDown("escape") && pauser == false)
        {
            Unpause();
        }
        if (Time.timeScale == 0)
        {
            Invoke("Pauserfalse", 0);
        }
        if (PlayerStats.Time <= 0 || timer.elapsedtime <= 0)
        {
            transition.newscene = 18;
        }
    } 
    public void Pause()
    {
        Debug.Log("yomama");
        PlayerStats.Errors = errors;
        PlayerStats.Completehold = completed;
        pausemenu.enabled = true;
        Time.timeScale = 0;
        pauser = true;
    }
    public void Unpause()
    {
        Debug.Log("yodady");
        PlayerStats.Errors = errors;
        PlayerStats.Completehold = completed;
        pausemenu.enabled = false;
        Time.timeScale = 1;
        pauser = true;
    }
    public void Pauserfalse()
    {
        pauser = false;
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

