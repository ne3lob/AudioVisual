using FullscreenEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerNovation : MonoBehaviour
{
    private NovationControlActionAsset input = null;
    [SerializeField] public float SendA1;
    [SerializeField] public float SendA2;
    private void OnEnable()
    {
        input.Enable();
        input.Novation.SendA1.performed += SendA1Func;
        input.Novation.SendA2.performed += SendA2Func;
    }

    private void OnDisable()
    {
        input.Novation.SendA1.performed -= SendA1Func;
        input.Novation.SendA2.performed -= SendA2Func;
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
    
    
}