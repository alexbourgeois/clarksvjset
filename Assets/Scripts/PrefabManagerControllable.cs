using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManagerControllable : Controllable
{
    [OSCMethod]
    public void TogglePrefab(int index)
    {
        (TargetScript as PrefabManager).TogglePrefab(index);
    }

    [OSCMethod]
    public void ToggleOffAll()
    {
        (TargetScript as PrefabManager).ToggleOffAll();
    }
    
    [OSCMethod]
    public void SetDirectionalIntensity(float value)
    {
        (TargetScript as PrefabManager).SetDirectionalIntensity(value);
    }

    [OSCMethod]
    public void SetBloomIntensity(float value)
    {
        (TargetScript as PrefabManager).SetBloomIntensity(value);
    }

    [OSCMethod]
    public void SetBrownianMotionPositionIntensityValue(float value)
    {
        (TargetScript as PrefabManager).SetBrownianMotionPositionIntensityValue(value);
    }

    [OSCMethod]
    public void SetBrownianMotionRotationIntensityValue(float value)
    {
        (TargetScript as PrefabManager).SetBrownianMotionRotationIntensityValue(value);
    }

    [OSCMethod]
    public void SetHueShift(float value)
    {
        (TargetScript as PrefabManager).SetHueShift(value);
    }

}

