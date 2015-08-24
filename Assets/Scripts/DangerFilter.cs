using UnityEngine;
using System.Collections;

public class DangerFilter : MonoBehaviour
{
    public float fadeSpeed = 1f;
    public float maxIntensity = 1.5f;
    public float minIntensity = 0.5f;
    public float resetMargin = 0.2f;
    public bool playerSighted;

    private Light filter;
    private float targetIntensity;

    void Awake()
    {
        filter = GetComponent<Light>();
        filter.intensity = 0f;
        targetIntensity = maxIntensity;
    }

    void Update()
    {
        if (playerSighted)
        {
            filter.intensity = Mathf.Lerp(filter.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            CheckTargetIntensity();
        }
        else
            filter.intensity = Mathf.Lerp(filter.intensity, 0f, fadeSpeed * Time.deltaTime);
    }

	void CheckTargetIntensity()
    {
        if(Mathf.Abs(targetIntensity - filter.intensity) < resetMargin)
        {
            if (targetIntensity >= maxIntensity - resetMargin)
                targetIntensity = minIntensity;
            else if (targetIntensity <= minIntensity + resetMargin)
                targetIntensity = maxIntensity;

        }
    }
}
