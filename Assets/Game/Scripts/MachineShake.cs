using Gameplay.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineShake : MonoBehaviour
{
    [SerializeField] private SO_InputKey shakeInputKey;
    [SerializeField] private float maxShake;
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeDistance;
    [SerializeField] private TMPro.TMP_Text tiltedText;
    private Vector3 basePosition;
    private float currentShakeLevel;
    private bool tilted;
    private bool shaking;

    public bool Tilted { get => tilted; private set => tilted = value; }

    private void Awake()
    {
        basePosition = transform.position;
    }
    private void Update()
    {
        if (shakeInputKey.IsKeyPress && !tilted && !shaking)
        {
            StartCoroutine(Shake());
        }
        if (tilted)
        {
            if (!BallSpawner.Instance.BallInPlay())
            {
                tilted = false;
                InputManager.Instance.EnableGameplayInput();
                tiltedText.gameObject.SetActive(false);
            }
        }
        if (currentShakeLevel > 0 && !shaking)
            currentShakeLevel -= Time.deltaTime;
    }

    private IEnumerator Shake()
    {
        shaking = true;
        bool reversed = false;
        while (shakeInputKey.IsKeyPress)
        {
            currentShakeLevel += Time.deltaTime;
            if (currentShakeLevel >= maxShake)
            {
                TiltMachine();
                break;
            }

            Vector3 targetPosition = basePosition;
            targetPosition.x -= shakeDistance;
            if (targetPosition.x >= transform.position.x)
                reversed = true;

            if (reversed)
            {
                targetPosition = basePosition;
                targetPosition.x += shakeDistance;
            }

            if (targetPosition.x <= transform.position.x)
                reversed = false;

            Vector3 newPosition = transform.position;
            newPosition.x += Vector3.Lerp(basePosition, targetPosition, Time.deltaTime * shakeIntensity).x;
            transform.position = newPosition;
            yield return null;
        }
        shaking = false;
        transform.position = basePosition;
    }

    private void TiltMachine()
    {
        tilted = true;
        InputManager.Instance.DisableGameplayInput();
        tiltedText.gameObject.SetActive(true);
    }
}
