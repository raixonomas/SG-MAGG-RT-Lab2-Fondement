using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BumperEffectScript : MonoBehaviour
{
    private Color defaultColor;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color activatedColor = Color.red;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            spriteRenderer.color = activatedColor;
            StartCoroutine(ResetColor());
        }
    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.5f);
       
        spriteRenderer.color = defaultColor;
    }
}
