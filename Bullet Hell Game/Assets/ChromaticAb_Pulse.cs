using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class ChromaticAb_Pulse : MonoBehaviour
{
    //https://forum.unity.com/threads/fade-chromatic-aberration-via-code.892849/

    float time = 20f;

    ChromaticAberration chromatic;
    PostProcessVolume volumeChromatic;

    float targetChromaticIntensityLower  = 0f;
    float targetChromaticIntensityUpper  = 0.8f;
    float currentChromaticIntensity = 0f;

    void Start() {
        chromatic = ScriptableObject.CreateInstance<ChromaticAberration>();
        chromatic.enabled.Override(true);
        chromatic.intensity.Override(targetChromaticIntensityUpper);
        volumeChromatic = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, chromatic);


    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (chromatic.intensity.value < targetChromaticIntensityUpper)
            {
                chromatic.intensity.value = currentChromaticIntensity + (targetChromaticIntensityUpper / time);
            }
            currentChromaticIntensity = chromatic.intensity.value;
        }
        if (!Input.GetButton("Fire1"))
        {
            if (chromatic.intensity.value >= targetChromaticIntensityLower)
            {
                chromatic.intensity.value = currentChromaticIntensity - (targetChromaticIntensityUpper / time);
            }
            currentChromaticIntensity = chromatic.intensity.value;
        }
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(volumeChromatic, true, true);
        
    }
}
