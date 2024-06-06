using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Errors : MonoBehaviour
{
    // Start is called before the first frame update
    public Rounds MyPlayer;
    [SerializeField] TextMeshProUGUI errortext;
    public Slider playererror;
 
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        errortext.text = (MyPlayer.errors.ToString() + "/" + MyPlayer.errorstotal).ToString();
        playererror.value = Mathf.Floor(MyPlayer.errors)/Mathf.Floor(MyPlayer.errorstotal);
    }
}
