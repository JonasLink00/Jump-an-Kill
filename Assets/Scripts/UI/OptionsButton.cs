using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{

    //legt fest was passiert wenn ein Button gedr�ckt wird 
    public void BackButton()
    {
        Szeneloader.Instance.UnLoadScene(SceneIndicies.Options);
    }
}
