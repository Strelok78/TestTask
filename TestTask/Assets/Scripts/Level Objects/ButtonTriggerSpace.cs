using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTriggerSpace : MonoBehaviour
{
    public event UnityAction<bool> OnTriggerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MakeAction(collision, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MakeAction(collision, false);
    }

    private void MakeAction(Collider2D collision, bool isPressed)
    {
        if (collision.TryGetComponent<HeroMovement>(out _) || collision.TryGetComponent<ItemSummoner>(out _))
            OnTriggerEnter?.Invoke(isPressed);
    }
}