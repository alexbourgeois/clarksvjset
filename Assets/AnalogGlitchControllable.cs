using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogGlitchControllable : Controllable
{
    [OSCProperty, Range(0, 1)]
    public float scanLineJitter = 0;

    [OSCProperty, Range(0, 1)]
    public float verticalJump = 0;

    [OSCProperty, Range(0, 1)]
    public float horizontalShake = 0;

    [OSCProperty, Range(0, 1)]
    public float colorDrift = 0;
}
