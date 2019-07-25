using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettingsControllable : Controllable
{
    [OSCProperty]
    public float timeScale = 1.0f;
   
}
