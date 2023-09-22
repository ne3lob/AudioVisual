using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraRotationScript : MonoBehaviour
{
    private ControlMapping _controlMapping;
    private Vector2 move;
    private Vector2 inOut;
    public GameObject pivPos;
    private Vector3 resetPosition;
    public Vector3 originalRotationValue;
    bool boolResetPosition;

   [SerializeField]public float speedrotation;
   [SerializeField]public float speedzoom;

    public InputDevice button;

    private void Awake()
    {
        _controlMapping = new ControlMapping();
    }

    void Start()
    {
        _controlMapping.Mapping.CameraMoveAround.performed += cnxt => move = cnxt.ReadValue<Vector2>();
        _controlMapping.Mapping.CameraMoveAround.canceled += cnxt => move = Vector2.zero;

        _controlMapping.Mapping.CameraOutIn.performed += cnxt => inOut = cnxt.ReadValue<Vector2>();
        _controlMapping.Mapping.CameraOutIn.canceled += cnxt => inOut = Vector2.zero;

        _controlMapping.Mapping.ResetRot.performed += ResetRot;
        _controlMapping.Mapping.ResetPos.performed += ResetPos;

        resetPosition = pivPos.transform.position;
        originalRotationValue = transform.rotation.eulerAngles; // save the initial rotation
    }

    private void ResetPos(InputAction.CallbackContext obj)
    {
        StartCoroutine(SmoothLerp(3f));
        obj.ReadValueAsButton();
    }


    private void ResetRot(InputAction.CallbackContext obj)
    {
        obj.ReadValueAsButton();
        StartCoroutine(LerpFunction(Quaternion.Euler(originalRotationValue), 3));
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 m = new Vector3(-move.y, move.x, 0);
        transform.Rotate(m * speedrotation);

        Vector3 zoom = new Vector3(0, 0, inOut.y);
        pivPos.transform.Translate(Vector3.forward * zoom.z * speedzoom);
    }

    private IEnumerator SmoothLerp(float time)
    {
        Vector3 startingPos = pivPos.transform.position;
        Vector3 finalPos = resetPosition;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            pivPos.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        Debug.Log($"<color=green>RESET POSITION</color>");
    }


    IEnumerator LerpFunction(Quaternion endValue, float duration)
    {
        float time = 0;
        Quaternion startValue = transform.rotation;
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endValue;

        Debug.Log($"<color=yellow>RESET ROTATION</color>");
    }


    private void OnEnable()
    {
        _controlMapping.Enable();
    }

    private void OnDisable()
    {
        _controlMapping.Disable();
    }
}