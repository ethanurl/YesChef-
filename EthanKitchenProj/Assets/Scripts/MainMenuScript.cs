using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Animator transition;
    public float transitiontime = 1f;
    void Update()
    {
    }

    
    public void starter()
    {
        StartCoroutine(LoaderLeveler(13));
    }
    public void optionwonderer()
    {
        StartCoroutine(LoaderLeveler(15));
    }
    public void creditgoer()
    {
        StartCoroutine(LoaderLeveler(16));
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
