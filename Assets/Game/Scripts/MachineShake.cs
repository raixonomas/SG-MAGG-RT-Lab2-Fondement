using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineShake : MonoBehaviour
{
    [SerializeField] private float maxShake;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeDistance;
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
        // TODO: REPLACE ME
        if (Input.GetKeyDown(KeyCode.Space) && !tilted)
        {
            StartCoroutine(Shake());
        }
        if (tilted)
            tilted = ballSpawner.BallInPlay();
        if (currentShakeLevel > 0 && !shaking)
            currentShakeLevel -= Time.deltaTime;
    }

    private IEnumerator Shake()
    {
        shaking = true;
        bool reversed = false;
        // TODO: REPLACE ME
        while (Input.GetKey(KeyCode.Space))
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
        Debug.Log("finished shaking");
        transform.position = basePosition;
    }

    private void TiltMachine()
    {
        tilted = true;
        Debug.Log("tilted");
    }
}
