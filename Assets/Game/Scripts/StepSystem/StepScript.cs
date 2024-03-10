using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepScript : MonoBehaviour
{
    private StepSystemScript stepSystem;
    private SpriteRenderer spriteRenderer;
    private bool hasBeenActivated = false;
    private Color defaultColor;

    [SerializeField] private Color activatedColor = Color.red;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
        stepSystem = gameObject.GetComponentInParent<StepSystemScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball" && !hasBeenActivated)
        {
            ActivateStep();
        }               
    }

    private void ActivateStep()
    {
        hasBeenActivated = true;
        stepSystem.StepTrigger();
        spriteRenderer.color = activatedColor;
    }

    public void ResetStep()
    {
        hasBeenActivated = false;
        spriteRenderer.color = defaultColor;
    }

}
