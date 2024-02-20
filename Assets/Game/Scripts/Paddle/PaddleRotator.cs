using Gameplay.Input;
using UnityEngine;

public class PaddleRotator : MonoBehaviour
{
    [Header("Input Data")] [SerializeField]
    private SO_InputKey paddleInputKey;

    [Header("Paddle Data")] [SerializeField]
    private GameObject Child;
    [SerializeField] private float RotationSpeed = 1.0f;
    [SerializeField] private bool IsLeftPaddle = true;

    [Header("Angle Data")] [SerializeField]
    private float MinAngle;

    [SerializeField] private float DefaultAngle;
    [SerializeField] private float MaxAngle;

    private Coroutine ResetPaddleRoutine;


    private void Awake()
    {
        DefaultAngle = !IsLeftPaddle ? DefaultAngle * -1f : DefaultAngle;
        MinAngle = !IsLeftPaddle ? MinAngle * -1f : MinAngle;
        MaxAngle = !IsLeftPaddle ? MaxAngle * -1f : MaxAngle;
        
        Child.transform.SetParent(transform);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, DefaultAngle));
    }

    private void Update()
    {
        OnHoldKey();
        OnReleaseKey();
    }


    private void OnHoldKey()
    {
        if (!paddleInputKey.IsKeyPress) return;
       
        var desiredRot = Quaternion.Euler(new Vector3(0, 0, MaxAngle));
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot, RotationSpeed * Time.deltaTime);
    }

    private void OnReleaseKey()
    {
        if (paddleInputKey.IsKeyPress) return;
       
        var desiredRot = Quaternion.Euler(new Vector3(0, 0, MinAngle));
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot, RotationSpeed * Time.deltaTime);

    }
  
}