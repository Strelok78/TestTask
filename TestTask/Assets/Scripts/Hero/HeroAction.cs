using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class HeroAction : MonoBehaviour
{
    [SerializeField] GameObject _item;
    [SerializeField] Color _heroWaitColor;
    [SerializeField] float _itemSummonDistance;

    private SpriteRenderer _spriteRenderer;
    private Color _mainColor;

    public event UnityAction<Transform> OnItemSummon;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _mainColor = _spriteRenderer.color;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && CheckDistance())
        {
            _item.SetActive(false);
            ChangeColor();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && _item.activeSelf == false)
        {
            SummonItem();
            ChangeColor();
        }
    }

    private bool CheckDistance()
    {
        return _itemSummonDistance < Vector2.Distance(transform.position, _item.transform.position);
    }

    private void ChangeColor()
    {
        if (_item.activeSelf == false)
            _spriteRenderer.color = _heroWaitColor;
        else
            _spriteRenderer.color = _mainColor;
    }

    private void SummonItem()
    {
        _item.SetActive(true);
        OnItemSummon?.Invoke(transform);
    }
}
