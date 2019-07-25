using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalGlitchControllable : Controllable
{
    [OSCProperty, Range(0, 1)]
    public float intensity = 0;
}
