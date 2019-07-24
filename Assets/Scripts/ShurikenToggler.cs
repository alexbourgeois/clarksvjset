using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenToggler : MonoBehaviour
{
    public GameObject effect;

    private void OnEnable()
    {
        effect.SetActive(true);
    }

    private void OnDisable()
    {
        effect.SetActive(false);
    }
}
