using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Video;

public class VolumeUpdater : MonoBehaviour
{
    //VIDEOS
    // [Header("VIDEOS")]
    //
    // [SerializeField] private GameObject Video1;
    // [Range(0, 1)] [SerializeField] private float SpeedCloudsFantastic;
    // [Range(0, 1)] [SerializeField] private float AlphaCloudsFantastic;
    //
    // [SerializeField] private GameObject Video2;
    // [Range(0, 10)] [SerializeField] private float SpeedWITCHES;
    // [Range(0, 1)] [SerializeField] private float AlphaWITCHES;
    //
    // [SerializeField] private GameObject Video3;
    // [Range(9,10)] [SerializeField] private float SpeedYellow;
    // [Range(0, 1)] [SerializeField] private float AlphaYellow;
    //
    // [SerializeField] private GameObject WaterPlane;
    // [Range(0, 10)] [SerializeField] private float SpeedWater;
    // [Range(0, 1)] [SerializeField] private float AlphaWater;
    // [Range(0, 1)] [SerializeField] private float SmoothnessWater;
    // private Material waterMaterial;
    //
    // private VideoPlayer video1player;
    // private VideoPlayer video2player;
    // private VideoPlayer video3player;
    //
    // // FLOWER
    // [Header("FLOWER")]
    //
    // [SerializeField] private MeshRenderer[] Flowers;
    // [Range(0,1)] [SerializeField] private float FlowerSpeed;
    // [Range(0,1)] [SerializeField] private float FlowerAlpha;
    //
    // // OCEAN
    // [Header("OCEAN")] 
    //
    // [SerializeField] private GameObject Ocean;
    // private Material oceanMaterial;
    // [Range(0.1f, 1f)] [SerializeField] private float OceanScale;
    private InputManagerNovation inputScript;
    // VOLUME
    [Header("VOLUME")]

    [SerializeField] private Volume Volume;
    private Bloom bloom;
    private Vignette vignette;
    private WhiteBalance whiteBalance;
    
    private ColorAdjustments colorAdjustments;
    
    [Range(0,1)] [SerializeField] private float bloomWeight;
    [Range(-100,100)] [SerializeField] private float temperature;
    [Range(0, 1)] [SerializeField] private float vinigretteWeight;
    [Range(0, 100)] [SerializeField] private float dirtWeight;
    [Range(0,1)] [SerializeField] private float scatterWeight;
    
    // Start is called before the first frame update
    void Start()
    {
        inputScript = GetComponent<InputManagerNovation>();
       
    }

    // Update is called once per frame
    void Update()
    {
     
        bloomWeight = inputScript.SendA1;
        scatterWeight=  inputScript.SendA1;
        dirtWeight= inputScript.SendA1*100;
        vinigretteWeight = inputScript.SendA1;
        temperature = (inputScript.SendA1*200f)-100f;
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
            bloom.dirtIntensity.value =dirtWeight;
        }
        if (Volume.profile.TryGet<Vignette>(out vignette))
        {
            vignette.intensity.value =vinigretteWeight;
        }
        if (Volume.profile.TryGet<WhiteBalance>(out whiteBalance))
        {
            whiteBalance.temperature.value = temperature;
        }
        
      
    }
}
