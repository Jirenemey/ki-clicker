using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayKi : MonoBehaviour
{
    public Text ki;

    void Update(){
        GameLogic.instance.DisplayKi();
    }

}
