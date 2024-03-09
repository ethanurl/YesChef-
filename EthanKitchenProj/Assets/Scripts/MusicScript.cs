using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.SceneManagement.Scene currentscene = SceneManager.GetActiveScene();
        if (currentscene.name == "GameOverWin" || currentscene.name == "GameOverLose")
        {
            StartCoroutine(endmusic());
        }
        DontDestroyOnLoad(this);
        
    }
    IEnumerator endmusic()
    {
        yield return new WaitForSecondsRealtime(1);
        Destroy(this.gameObject);
    }
}
