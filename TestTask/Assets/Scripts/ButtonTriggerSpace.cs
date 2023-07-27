using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTriggerSpace : MonoBehaviour
{
    public event UnityAction<bool> OnTriggerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HeroMovement>(out _))
            OnTriggerEnter?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HeroMovement>(out _) ) //добавить item
            OnTriggerEnter?.Invoke(false);
    }
}