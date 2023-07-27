using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SunroofAnimation : MonoBehaviour
{
    [SerializeField] private ButtonTriggerSpace _buttonTriggerSpace;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _buttonTriggerSpace.OnTriggerEnter += Open;
    }

    private void OnDisable()
    {
        _buttonTriggerSpace.OnTriggerEnter -= Open;
    }

    private void Open(bool isOpen)
    {
        if (isOpen)
            _animator.Play("SunroofOpen");
        else
            _animator.Play("SunroofClose");            
    }
}
