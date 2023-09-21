using FullscreenEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerNovation : MonoBehaviour
{
    private NovationControlActionAsset input = null;
    [SerializeField] public float SendA1;

    private void OnEnable()
    {
        input.Enable();
        input.Novation.SendA1.performed += SendA1Func;
    }

    private void OnDisable()
    {
        input.Novation.SendA1.performed -= SendA1Func;
        input.Disable();
    }

    private void Awake()
    {
        input = new NovationControlActionAsset();
    }


    private void SendA1Func(InputAction.CallbackContext value)
    {
        SendA1 = value.ReadValue<float>();
    }
    
}