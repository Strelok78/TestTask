using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunroofMove : MonoBehaviour
{
    [SerializeField] private ButtonTriggerSpace _buttonTriggerSpace;
    [SerializeField] private float _distanceToHide = 3f;

    private Vector3 _closedPosition;
    private Vector3 _openPosition;
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _closedPosition = transform.localPosition;
        _openPosition = new(transform.localPosition.x - _distanceToHide, transform.localPosition.y, transform.localPosition.z);
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
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = isOpen ? StartCoroutine(MoveSunroof(_openPosition)) : StartCoroutine(MoveSunroof(_closedPosition));
    }

    IEnumerator MoveSunroof(Vector3 targetPosition)
    {
        for (float i = 0; i < 1; i += 0.01f * Time.deltaTime)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, i);
            yield return new WaitForSeconds(0f);
        }
    }
}
