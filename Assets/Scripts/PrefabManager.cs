using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public PostProcessController ppController;

    public Light directional;

    public Klak.Motion.BrownianMotion brownian;

    public void TogglePrefab(int index)
    {
        var prefab = transform.GetChild(index).gameObject;
        prefab.SetActive(!prefab.activeInHierarchy);
    }

    public void SetDirectionalIntensity(float value)
    {
        directional.intensity = value;
    }

    public void SetBloomIntensity(float value)
    {
        ppController.bloomIntensity = value;
        ppController.UpdateBloomIntensity(ppController.bloomIntensity);
    }

    public void SetHueShift(float value)
    {
        ppController.colorGradingHueShift = value;
        ppController.UpdateColorGradingHueShift(ppController.colorGradingHueShift);
    }

    public void SetBrownianMotionPositionIntensityValue(float value)
    {
        brownian.positionAmplitude = value;
    }

    public void SetBrownianMotionRotationIntensityValue(float value)
    {
        brownian.rotationAmplitude = value;
    }

    public void ToggleOffAll()
    {
        for(var i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(var i=0; i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
