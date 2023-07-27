using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class ButtonPlatform : MonoBehaviour
{
    [SerializeField] private ButtonTriggerSpace _buttonTriggerSpace;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _buttonTriggerSpace.OnTriggerEnter += ChangeColor;
    }

    private void OnDisable()
    {
        _buttonTriggerSpace.OnTriggerEnter -= ChangeColor;
    }

    private void ChangeColor(bool isPressed)
    {
        if (isPressed)
            _spriteRenderer.color = Color.red;
        else
            _spriteRenderer.color = Color.yellow;
    }
}