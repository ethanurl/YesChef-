using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlsScript : MonoBehaviour
{
    public GameObject text;
    public GameObject controltext;
    public Animator transition;
    public GameObject controls;
    public GameObject closecontrols;
    // Start is called before the first frame update
    void Start()
    {
        controltext.SetActive(false);
        closecontrols.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Controls()
    {
        controls.SetActive(false);
        closecontrols.SetActive(true);
        controltext.SetActive(true);
        text.SetActive(false);
    }
    public void CloseControls()
    {
        controls.SetActive(true);
        closecontrols.SetActive(false);
        controltext.SetActive(false);
        text.SetActive(true);
    }
    public void StartButton()
    {
        StartCoroutine(LoaderLeveler(13));
    }

    IEnumerator LoaderLeveler(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f); 
        SceneManager.LoadScene(levelIndex);  
    }
}
