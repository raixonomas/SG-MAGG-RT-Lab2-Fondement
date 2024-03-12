using UnityEngine;

public class Rotator3D : MonoBehaviour
{
    [SerializeField] private float RotationAmount = 10f;
    [SerializeField] private float RotSpeed = 10f;

    private float CurrentRotation = 0f;

    void Update()
    {
        CurrentRotation += RotationAmount * Time.deltaTime * RotSpeed;

        if (CurrentRotation >= 360)
        {
            CurrentRotation = 0;
        }
        var desiredRot = Quaternion.Euler(new Vector3(CurrentRotation, CurrentRotation, CurrentRotation));
        transform.rotation = desiredRot;
    }
}