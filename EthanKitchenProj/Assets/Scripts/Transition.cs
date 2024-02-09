using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int newscene = -1;
    public Animator transition;
    public float transitiontime = 1f;
    void Update()
    {
        if (newscene > -1){
            LoadLevel();
        }
    }
    public void LoadLevel()
    {
        StartCoroutine(LoaderLeveler(newscene));
        newscene = -1;
    }
    IEnumerator LoaderLeveler(int levelIndex)
    {
        
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime); 
        SceneManager.LoadScene(levelIndex);  
    }
}
