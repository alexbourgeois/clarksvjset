using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public float timeScale = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }
}
