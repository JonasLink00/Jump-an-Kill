using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    
    public void BackButton()
    {
        Szeneloader.Instance.UnLoadScene(SceneIndicies.Options);
    }
}
