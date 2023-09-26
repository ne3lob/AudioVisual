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
    public VisualEffect vfxOne;
    public VisualEffect vfxTwo;

    private InputManagerNovation inputScript;

    // VOLUME
    [Header("VOLUME")] [SerializeField] private Volume Volume;
    private Bloom bloom;
    private Vignette vignette;
    private Bloom dirt;
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
        bloomWeight = inputScript.Slider5;
         scatterWeight = inputScript.Slider6;
         dirtWeight = inputScript.Slider7 * 10;
         vinigretteWeight = inputScript.Slider8;
         temperature = (inputScript.SendPan8 * 200f) - 100f;
        vfxOne.SetFloat("Setsize", inputScript.SendA5 * 0.15f);
        vfxOne.SetFloat("SetVectorVelocity", inputScript.SendA6 * 0.5f);
        vfxTwo.SetFloat("SizeVfX2", inputScript.SendB5 * 0.15f);
        vfxTwo.SetFloat("SetVelocytyVFX2", inputScript.SendB6 * 0.5f);
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

        if (Volume.profile.TryGet<Bloom>(out dirt))
        {
           dirt.dirtIntensity.value = dirtWeight;
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