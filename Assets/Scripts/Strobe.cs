using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Strobe : MonoBehaviour
{
    public CameraFadeToColor fadeToColor;

    public float duration;
    public AnimationCurve curve;

    // Start is called before the first frame update
    void OnEnable()
    {
        //fadeToColor.FadeColor = Color.HSVToRGB(UnityEngine.Random.value, 1.0f, 1.0f);
        //fadeToColor.ChangeFadeColor(fadeToColor.FadeColor);

        StopAllCoroutines();
        StartCoroutine(fade(0.0f, 1.0f, duration, curve, Callback));
    }

    private void OnDisable()
    {
        fadeToColor.FadeValue = 0.0f;
    }

    void Callback()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator fade(float start, float end, float duration, AnimationCurve curve, Action callback = null)
    {
        var currentTime = 0.0f;
        while (currentTime / duration < 1)
        {
            fadeToColor.FadeValue= Mathf.Lerp(start, end, curve.Evaluate(currentTime / duration)); ;
            currentTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        callback?.Invoke();
    }
}
