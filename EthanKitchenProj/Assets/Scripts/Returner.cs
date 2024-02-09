using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Returner : MonoBehaviour
{
    private int newscene = 13;
    public Animator transition;
    public float transitiontime = 1f;
    public bool completed = false;
    void Update()
    {
        if (Input.GetKeyDown("j")){
            LoadLevel();
        }
        if (completed == true){
            completed = false;
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
    // Update is called once per frame

//    void Update()
//    {
//       if (Input.GetKeyDown("e")){
//        StartCoroutine(LoadGameScene());
//       };  
//    }
//    IEnumerator LoadGameScene(){
//        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameScene");
//        while (!asyncLoad.isDone){
//            yield return null;
//        }
//    }
//}
