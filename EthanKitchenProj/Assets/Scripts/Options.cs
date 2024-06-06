using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject Background;
    public float slidervalue = 1f;
    public GameObject OptionsMenu;
    public GameObject PauseMenu;
    public Slider sliderer;
    void Update()
    {
        Sprite NoVolume = Resources.Load<Sprite>("Sprites/NoVolume");
        Sprite LowVolume = Resources.Load<Sprite>("Sprites/LowVolume");
        Sprite MidVolume = Resources.Load<Sprite>("Sprites/MidVolume");
        Sprite HighVolume = Resources.Load<Sprite>("Sprites/HighVolume");
        if (sliderer.value == 0f){
            Background.GetComponent<Image>().sprite = NoVolume;
        }
        if (sliderer.value > 0f){
            if (sliderer.value < 0.35f)
                Background.GetComponent<Image>().sprite = LowVolume;
        }
        if (sliderer.value >= 0.35f){
            if (sliderer.value < 0.70f)
                Background.GetComponent<Image>().sprite = MidVolume;
        }
        if (sliderer.value > 0.70f){
                Background.GetComponent<Image>().sprite = HighVolume;
        }
    }
    public void fullscreener()
    {
        /*this code from unity docs*/
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void audioer()
    {
        slidervalue = sliderer.value;
        if (sliderer.value != 0f){
            Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/NoVolume");
            sliderer.value = 0f;
            AudioListener.volume = slidervalue;
        }
        if (sliderer.value == 0f){
            sliderer.value = slidervalue;
            AudioListener.volume = slidervalue;
        }
    }
    public void audioslider()
    {
        slidervalue = sliderer.value;
        AudioListener.volume = slidervalue;
    }
    public void returner()
    {
        OptionsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }
}