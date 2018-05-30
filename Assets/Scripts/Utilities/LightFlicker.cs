using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    Light light;
    bool change;
    public float intervalo;
    float min, med, max;

    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();
        min = light.intensity;
        max = light.intensity + light.intensity * 0.1f;
        med = (min + max) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Flicker(intervalo));
    }

    IEnumerator Flicker(float waittime)
    {
        if (light.intensity == min)
        {
            yield return new WaitForSeconds(waittime);
            light.intensity = med;
        }
        else if (light.intensity == med)
        {
            yield return new WaitForSeconds(waittime);
            light.intensity = max;
        }
        else
        {
            yield return new WaitForSeconds(waittime);
            light.intensity = min;
        }
    }
}