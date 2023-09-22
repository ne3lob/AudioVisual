using FullscreenEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerNovation : MonoBehaviour
{
    private NovationControlActionAsset input = null;
    [SerializeField] public float SendA1;
    [SerializeField] public float SendA2;
    [SerializeField] public float SendA3;
    [SerializeField] public float SendA4;
    
    [SerializeField] public float SendPan1;
    [SerializeField] public float SendPan2;
    [SerializeField] public float SendPan3;
    
    [SerializeField] public float Slider1;
    [SerializeField] public float Slider2;
    
    private void OnEnable()
    {
        input.Enable();
        
        input.Novation.SendA1.performed += SendA1Func;
        input.Novation.SendA2.performed += SendA2Func;
        input.Novation.SendA3.performed += SendA3Func;
        input.Novation.SendA4.performed += SendA4Func;
        
        input.Novation.SendPan1.performed += SendPan1Func;
        input.Novation.SendPan2.performed += SendPan2Func;
        input.Novation.SendPan3.performed += SendPan3Func;
        
        input.Novation.Slider1.performed += Slider1Func;
        input.Novation.Slider2.performed += Slider2Func;
    }

    private void OnDisable()
    {
        input.Novation.SendA1.performed -= SendA1Func;
        input.Novation.SendA2.performed -= SendA2Func;
        input.Novation.SendA3.performed -= SendA3Func;
        input.Novation.SendA4.performed -= SendA4Func;
        
        input.Novation.SendPan1.performed -= SendPan1Func;
        input.Novation.SendPan2.performed -= SendPan2Func;
        input.Novation.SendPan3.performed -= SendPan3Func;
        
        input.Novation.Slider1.performed -= Slider1Func;
        input.Novation.Slider2.performed -= Slider2Func;
        
        input.Disable();
    }

    private void Awake()
    {
        input = new NovationControlActionAsset();
    }


    private void SendA1Func(InputAction.CallbackContext value1)
    {
        SendA1 = value1.ReadValue<float>();
        Debug.Log( value1);
        
    }
    private void SendA2Func(InputAction.CallbackContext value2)
    {
        SendA2 = value2.ReadValue<float>();
        Debug.Log( value2);
    }
    private void Slider1Func(InputAction.CallbackContext value3)
    {
        Slider1 = value3.ReadValue<float>();
        Debug.Log( value3);
    }
    private void Slider2Func(InputAction.CallbackContext value4)
    {
        Slider2 = value4.ReadValue<float>();
        Debug.Log( value4);
    }
    private void SendA3Func(InputAction.CallbackContext value5)
    {
        SendA3 = value5.ReadValue<float>();
        Debug.Log( value5);
    }
    private void SendPan1Func(InputAction.CallbackContext value6)
    {
        SendPan1 = value6.ReadValue<float>();
        Debug.Log( value6);
    }
    private void SendPan2Func(InputAction.CallbackContext value7)
    {
        SendPan2 = value7.ReadValue<float>();
        Debug.Log( value7);
    }
    private void SendPan3Func(InputAction.CallbackContext value8)
    {
        SendPan3 = value8.ReadValue<float>();
        Debug.Log( value8);
    }
    private void SendA4Func(InputAction.CallbackContext value10)
    {
        SendA4 = value10.ReadValue<float>();
        Debug.Log( value10);
    }
}