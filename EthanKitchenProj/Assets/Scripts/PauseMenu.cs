using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Animator transition;
    public float transitiontime = 1f;
    public GameObject OptionsMenu;
    public GameObject PauserMenur;
    void Update()
    {
    }

    
    public void gameresumer()
    {
        StartCoroutine(LoaderLeveler(13));
    }
    public void optionwonderer()
    {
        OptionsMenu.SetActive(true);
        PauserMenur.SetActive(false);
    }
    public void creditgoer()
    {
        Time.timeScale = 1;
        StartCoroutine(LoaderLeveler(16));
    }
    public void mainmenuer()
    {
        Time.timeScale = 1;
        PlayerStats.Errors = 0;
        PlayerStats.Completehold = 0;
        PlayerStats.Completed = 0;
        PlayerStats.Time = 0;
        
        StartCoroutine(LoaderLeveler(0));
    }
    public void quitter()
    {
        Application.Quit();
    }

    IEnumerator LoaderLeveler(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime); 
        SceneManager.LoadScene(levelIndex);  
    }
}
