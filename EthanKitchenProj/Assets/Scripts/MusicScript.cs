using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    public AudioSource Music;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.Music == false)
        {
            Music.Play();
            PlayerStats.Music = true;
        }
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
        PlayerStats.Music = false;
    }
    public void endmusic2()
    {
        Destroy(this.gameObject);
        PlayerStats.Music = false;
    }
}
