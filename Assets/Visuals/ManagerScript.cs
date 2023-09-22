using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Video;

public class ManagerScript : MonoBehaviour
{
    private InputManagerNovation novationInput;
    
    //VIDEOS
    [Header("VIDEOS")]
    
    [SerializeField] private GameObject Video1;
    [Range(0, 1)] [SerializeField] private float SpeedCloudsFantastic;
    [Range(0, 1)] [SerializeField] private float AlphaCloudsFantastic;
    
    [SerializeField] private GameObject Video2;
    [Range(0, 10)] [SerializeField] private float SpeedWITCHES;
    [Range(0, 1)] [SerializeField] private float AlphaWITCHES;
    
    [SerializeField] private GameObject Video3;
    [Range(0, 10)] [SerializeField] private float SpeedYellow;
    [Range(0, 1)] [SerializeField] private float AlphaYellow;
    
    [SerializeField] private GameObject WaterPlane;
    [SerializeField] private GameObject Video4;
    [Range(0, 10)] [SerializeField] private float SpeedWater;
    [Range(0, 1)] [SerializeField] private float AlphaWater;
    [Range(0, 1)] [SerializeField] private float SmoothnessWater;
    private Material waterMaterial;
    
    private VideoPlayer video1player;
    private VideoPlayer video2player;
    private VideoPlayer video3player;
    private VideoPlayer video4player;
    
    // FLOWER
    [Header("FLOWER")]
    
    [SerializeField] private MeshRenderer[] Flowers;
    [Range(0,1)] [SerializeField] private float FlowerSpeed;
    [Range(0,1)] [SerializeField] private float FlowerAlpha;

    // OCEAN
    [Header("OCEAN")] 
    
    [SerializeField] private GameObject Ocean;
    private Material oceanMaterial;
    [Range(0.1f, 1f)] [SerializeField] private float OceanScale;

    // VOLUME
    [Header("VOLUME")]

    [SerializeField] private Volume Volume;
    private Bloom bloom;
    private WhiteBalance whiteBalance;
    private ColorAdjustments colorAdjustments;
    
    [Range(0,100)] [SerializeField] private float bloomWeight;
    [Range(-100,100)] [SerializeField] private float temperature;
    [Range(-100,100)] [SerializeField] private float contrast;
    
    // Start is called before the first frame update
    void Start()
    {
        novationInput = GetComponent<InputManagerNovation>();
        
        video1player = Video1.GetComponent<VideoPlayer>();
        video2player = Video2.GetComponent<VideoPlayer>();
        video3player = Video3.GetComponent<VideoPlayer>();
        video4player = Video4.GetComponent<VideoPlayer>();

        waterMaterial = WaterPlane.GetComponent<MeshRenderer>().material;
        oceanMaterial = Ocean.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // VIDEO SETTINGS
        
        video1player.playbackSpeed = SpeedCloudsFantastic;
        video1player.targetCameraAlpha = AlphaCloudsFantastic;

        SpeedWITCHES = 10*novationInput.SendA3;
        AlphaWITCHES = novationInput.SendA4;
        video2player.playbackSpeed = SpeedWITCHES;
        video2player.targetCameraAlpha = AlphaWITCHES;

        
        AlphaYellow = novationInput.SendB2;
        SpeedYellow = 10*novationInput.SendB1;
        video3player.playbackSpeed = SpeedYellow;
        video3player.targetCameraAlpha = AlphaYellow;

        SpeedWater = 10*novationInput.SendPan4;
        video4player.playbackSpeed = SpeedWater;
        AlphaWater = novationInput.SendB3;
        SmoothnessWater = novationInput.SendB4;
        waterMaterial.SetFloat("_alpha", AlphaWater);
        waterMaterial.SetFloat("_smoothness", SmoothnessWater);
        
        // FLOWER
        foreach (var var in Flowers)
        {
            var.material.SetFloat("_FloatingStrength", FlowerSpeed);
            var.material.SetFloat("_alpha", novationInput.Slider1);
        }
        
        // OCEAN
        oceanMaterial.SetFloat("_NormalScale", novationInput.Slider2);
    }

    // VOLUME SETTINGS
    
    private void FixedUpdate()
    {
        // Connect values
        
        bloomWeight = 100*novationInput.SendPan1;
        temperature = (novationInput.SendPan2*200)-100;
        contrast = (novationInput.SendPan3*200) - 100;
        
        
        // Change values
        
        if (Volume.profile.TryGet<Bloom>(out bloom))
        {
            bloom.intensity.value = bloomWeight;
        }
        
        if (Volume.profile.TryGet<WhiteBalance>(out whiteBalance))
        {
            whiteBalance.temperature.value = temperature;
        }
        
        if (Volume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
        {
            colorAdjustments.contrast.value = contrast;
        }
    }
}
