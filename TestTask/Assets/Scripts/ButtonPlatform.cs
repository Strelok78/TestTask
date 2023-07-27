using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class ButtonPlatform : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        ChangeColor();
    }

    private bool IsPressed()
    {
        float rayLength = 0.1f;
        Vector2 boxSize = new(transform.localScale.x, transform.localScale.y);
        Vector2 boxPosition = new(_collider.bounds.center.x, _collider.bounds.max.y);

        RaycastHit2D standingObject = Physics2D.BoxCast(boxPosition, boxSize, 0f, Vector2.up, rayLength);

        if (standingObject.collider != null)
            Debug.Log(standingObject.collider.gameObject.name);

        Debug.DrawRay(new Vector2(_collider.bounds.min.x, _collider.bounds.max.y), Vector2.right, Color.white, transform.localScale.x);
        Debug.DrawRay(new Vector2(_collider.bounds.max.x, _collider.bounds.max.y), Vector2.down, Color.white, transform.localScale.y);
        Debug.DrawRay(new Vector2(_collider.bounds.max.x, _collider.bounds.min.y), Vector2.left, Color.white, transform.localScale.x);
        Debug.DrawRay(new Vector2(_collider.bounds.min.x, _collider.bounds.min.y), Vector2.up, Color.white, transform.localScale.y);

        return standingObject.collider != null && standingObject.collider.gameObject.name == "Hero";
    }

    private void ChangeColor()
    {
        if (IsPressed())
        {
            _spriteRenderer.color = Color.red;
        }
        else
        {
            _spriteRenderer.color = Color.yellow;
        }
    }
}