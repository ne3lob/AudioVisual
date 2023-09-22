using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Video;
using UnityEngine.VFX;

public class VolumeUpdater : MonoBehaviour
{
    public VisualEffect vfx;

    private InputManagerNovation inputScript;

    // VOLUME
    [Header("VOLUME")] [SerializeField] private Volume Volume;
    private Bloom bloom;
    private Vignette vignette;
    private WhiteBalance whiteBalance;

    private ColorAdjustments colorAdjustments;

    [Range(0, 1)] [SerializeField] private float bloomWeight;
    [Range(-100, 100)] [SerializeField] private float temperature;
    [Range(0, 1)] [SerializeField] private float vinigretteWeight;
    [Range(0, 100)] [SerializeField] private float dirtWeight;
    [Range(0, 1)] [SerializeField] private float scatterWeight;

    // Start is called before the first frame update
    void Start()
    {
        inputScript = GetComponent<InputManagerNovation>();
        //vfx = GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        bloomWeight = inputScript.SendA1;
        scatterWeight = inputScript.SendA1;
        dirtWeight = inputScript.SendA1 * 100;
        vinigretteWeight = inputScript.SendA1;
        temperature = (inputScript.SendA1 * 200f) - 100f;
        vfx.SetFloat("Setsize", inputScript.SendA1 * 0.15f);
        vfx.SetFloat("SetVectorVelocity", inputScript.SendA1 * 0.5f);
    }

    // VOLUME SETTINGS

    private void FixedUpdate()
    {
        if (Volume.profile.TryGet<Bloom>(out bloom))
        {
            bloom.intensity.value = bloomWeight;
        }

        if (Volume.profile.TryGet<Bloom>(out bloom))
        {
            bloom.scatter.value = scatterWeight;
        }

        if (Volume.profile.TryGet<Bloom>(out bloom))
        {
            bloom.dirtIntensity.value = dirtWeight;
        }

        if (Volume.profile.TryGet<Vignette>(out vignette))
        {
            vignette.intensity.value = vinigretteWeight;
        }

        if (Volume.profile.TryGet<WhiteBalance>(out whiteBalance))
        {
            whiteBalance.temperature.value = temperature;
        }
    }
}