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
    [SerializeField] public float SendA5;
    [SerializeField] public float SendA6;
    [SerializeField] public float SendA7;
    [SerializeField] public float SendA8;
    
    [SerializeField] public float SendB1;
    [SerializeField] public float SendB2;
    [SerializeField] public float SendB3;
    [SerializeField] public float SendB4;
    [SerializeField] public float SendB5;
    [SerializeField] public float SendB6;
    [SerializeField] public float SendB7;
    [SerializeField] public float SendB8;
    
    [SerializeField] public float SendPan1;
    [SerializeField] public float SendPan2;
    [SerializeField] public float SendPan3;
    [SerializeField] public float SendPan4;
    [SerializeField] public float SendPan5;
    [SerializeField] public float SendPan6;
    [SerializeField] public float SendPan7;
    [SerializeField] public float SendPan8;
    
    [SerializeField] public float Slider1;
    [SerializeField] public float Slider2;
    [SerializeField] public float Slider3;
    [SerializeField] public float Slider4;
    [SerializeField] public float Slider5;
    [SerializeField] public float Slider6;
    [SerializeField] public float Slider7;
    [SerializeField] public float Slider8;
    
    private void OnEnable()
    {
        input.Enable();
        
        input.Novation.SendA1.performed += SendA1Func;
        input.Novation.SendA2.performed += SendA2Func;
        input.Novation.SendA3.performed += SendA3Func;
        input.Novation.SendA4.performed += SendA4Func;
        input.Novation.SendA5.performed += SendA5Func;
        input.Novation.SendA6.performed += SendA6Func;
        input.Novation.SendA7.performed += SendA7Func;
        input.Novation.SendA8.performed += SendA8Func;
        
        input.Novation.SendB1.performed += SendB1Func;
        input.Novation.SendB2.performed += SendB2Func;
        input.Novation.SendB3.performed += SendB3Func;
        input.Novation.SendB4.performed += SendB4Func;
        input.Novation.SendB5.performed += SendB5Func;
        input.Novation.SendB6.performed += SendB6Func;
        input.Novation.SendB7.performed += SendB7Func;
        input.Novation.SendB8.performed += SendB8Func;
        
        input.Novation.SendPan1.performed += SendPan1Func;
        input.Novation.SendPan2.performed += SendPan2Func;
        input.Novation.SendPan3.performed += SendPan3Func;
        input.Novation.SendPan4.performed += SendPan4Func;
        input.Novation.SendPan5.performed += SendPan5Func;
        input.Novation.SendPan6.performed += SendPan6Func;
        input.Novation.SendPan7.performed += SendPan7Func;
        input.Novation.SendPan8.performed += SendPan8Func;
        
        input.Novation.Slider1.performed += Slider1Func;
        input.Novation.Slider2.performed += Slider2Func;
        input.Novation.Slider3.performed += Slider3Func;
        input.Novation.Slider4.performed += Slider4Func;
        input.Novation.Slider5.performed += Slider5Func;
        input.Novation.Slider6.performed += Slider6Func;
        input.Novation.Slider7.performed += Slider7Func;
        input.Novation.Slider8.performed += Slider8Func;
    }

    private void OnDisable()
    {
        input.Novation.SendA1.performed -= SendA1Func;
        input.Novation.SendA2.performed -= SendA2Func;
        input.Novation.SendA3.performed -= SendA3Func;
        input.Novation.SendA4.performed -= SendA4Func;
        input.Novation.SendA5.performed -= SendA5Func;
        input.Novation.SendA6.performed -= SendA6Func;
        input.Novation.SendA7.performed -= SendA7Func;
        input.Novation.SendA8.performed -= SendA8Func;
        
        input.Novation.SendB1.performed -= SendB1Func;
        input.Novation.SendB2.performed -= SendB2Func;
        input.Novation.SendB3.performed -= SendB3Func;
        input.Novation.SendB4.performed -= SendB4Func;
        input.Novation.SendB5.performed -= SendB5Func;
        input.Novation.SendB6.performed -= SendB6Func;
        input.Novation.SendB7.performed -= SendB7Func;
        input.Novation.SendB8.performed -= SendB8Func;
        
        input.Novation.SendPan1.performed -= SendPan1Func;
        input.Novation.SendPan2.performed -= SendPan2Func;
        input.Novation.SendPan3.performed -= SendPan3Func;
        input.Novation.SendPan4.performed -= SendPan4Func;
        input.Novation.SendPan5.performed -= SendPan5Func;
        input.Novation.SendPan6.performed -= SendPan6Func;
        input.Novation.SendPan7.performed -= SendPan7Func;
        input.Novation.SendPan8.performed -= SendPan8Func;
        
        input.Novation.Slider1.performed -= Slider1Func;
        input.Novation.Slider2.performed -= Slider2Func;
        input.Novation.Slider3.performed -= Slider3Func;
        input.Novation.Slider4.performed -= Slider4Func;
        input.Novation.Slider5.performed -= Slider5Func;
        input.Novation.Slider6.performed -= Slider6Func;
        input.Novation.Slider7.performed -= Slider7Func;
        input.Novation.Slider8.performed -= Slider8Func;
        
        input.Disable();
    }

    private void Awake()
    {
        input = new NovationControlActionAsset();
    }


    private void SendA1Func(InputAction.CallbackContext value1)
    {
        SendA1 = value1.ReadValue<float>();
        
        
    }
    private void SendA2Func(InputAction.CallbackContext value2)
    {
        SendA2 = value2.ReadValue<float>();
        
    }
    private void SendA3Func(InputAction.CallbackContext value3)
    {
        SendA3 = value3.ReadValue<float>();
        Debug.Log( value3);
    }
    private void SendA4Func(InputAction.CallbackContext value4)
    {
        SendA4 = value4.ReadValue<float>();
        Debug.Log( value4);
    }
    private void SendA5Func(InputAction.CallbackContext value5)
    {
        SendA5 = value5.ReadValue<float>();
        Debug.Log( value5);
    }
    private void SendA6Func(InputAction.CallbackContext value6)
    {
        SendA6 = value6.ReadValue<float>();
        Debug.Log( value6);
    }
    private void SendA7Func(InputAction.CallbackContext value7)
    {
        SendA7 = value7.ReadValue<float>();
        Debug.Log( value7);
    }
    private void SendA8Func(InputAction.CallbackContext value8)
    {
        SendA8 = value8.ReadValue<float>();
        Debug.Log( value8);
    }
    private void SendB1Func(InputAction.CallbackContext value9)
    {
        SendB1 = value9.ReadValue<float>();
        Debug.Log( value9);
    }
    private void SendB2Func(InputAction.CallbackContext value10)
    {
        SendB2 = value10.ReadValue<float>();
        Debug.Log( value10);
    }
    private void SendB3Func(InputAction.CallbackContext value11)
    {
        SendB3 = value11.ReadValue<float>();
        Debug.Log( value11);
    }
    private void SendB4Func(InputAction.CallbackContext value12)
    {
        SendB4 = value12.ReadValue<float>();
        Debug.Log( value12);
    }
    private void SendB5Func(InputAction.CallbackContext value13)
    {
        SendB5 = value13.ReadValue<float>();
        Debug.Log( value13);
    }
    private void SendB6Func(InputAction.CallbackContext value14)
    {
        SendB6 = value14.ReadValue<float>();
        Debug.Log( value14);
    }
    private void SendB7Func(InputAction.CallbackContext value15)
    {
        SendB7 = value15.ReadValue<float>();
        Debug.Log( value15);
    }
    private void SendB8Func(InputAction.CallbackContext value16)
    {
        SendB8 = value16.ReadValue<float>();
        Debug.Log( value16);
    }
    private void SendPan1Func(InputAction.CallbackContext value17)
    {
        SendPan1 = value17.ReadValue<float>();
        Debug.Log( value17);
    }
    private void SendPan2Func(InputAction.CallbackContext value18)
    {
        SendPan2 = value18.ReadValue<float>();
        Debug.Log( value18);
    }
    private void SendPan3Func(InputAction.CallbackContext value19)
    {
        SendPan3 = value19.ReadValue<float>();
        Debug.Log( value19);
    }
    private void SendPan4Func(InputAction.CallbackContext value20)
    {
        SendPan4 = value20.ReadValue<float>();
        Debug.Log( value20);
    }
    private void SendPan5Func(InputAction.CallbackContext value21)
    {
        SendPan5 = value21.ReadValue<float>();
        Debug.Log( value21);
    }
    private void SendPan6Func(InputAction.CallbackContext value22)
    {
        SendPan6 = value22.ReadValue<float>();
        Debug.Log( value22);
    }
    private void SendPan7Func(InputAction.CallbackContext value23)
    {
        SendPan7 = value23.ReadValue<float>();
        Debug.Log( value23);
    }
    private void SendPan8Func(InputAction.CallbackContext value24)
    {
        SendPan8 = value24.ReadValue<float>();
        Debug.Log( value24);
    }
    private void Slider1Func(InputAction.CallbackContext value25)
    {
        Slider1 = value25.ReadValue<float>();
        Debug.Log( value25);
    }
    private void Slider2Func(InputAction.CallbackContext value26)
    {
        Slider2 = value26.ReadValue<float>();
        Debug.Log( value26);
    }
    private void Slider3Func(InputAction.CallbackContext value27)
    {
        Slider3 = value27.ReadValue<float>();
        Debug.Log( value27);
    }
    private void Slider4Func(InputAction.CallbackContext value28)
    {
        Slider4 = value28.ReadValue<float>();
        Debug.Log( value28);
    }
    private void Slider5Func(InputAction.CallbackContext value29)
    {
        Slider5 = value29.ReadValue<float>();
        Debug.Log( value29);
    }
    private void Slider6Func(InputAction.CallbackContext value30)
    {
        Slider6 = value30.ReadValue<float>();
        Debug.Log( value30);
    }
    private void Slider7Func(InputAction.CallbackContext value31)
    {
        Slider7 = value31.ReadValue<float>();
        Debug.Log( value31);
    }
    private void Slider8Func(InputAction.CallbackContext value32)
    {
        Slider8 = value32.ReadValue<float>();
        Debug.Log( value32);
    }
}