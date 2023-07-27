using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSummoner : MonoBehaviour
{
    [SerializeField] private HeroAction _heroAction;
    [SerializeField] private float _basicDistanceToItem;

    private void OnEnable()
    {
        _heroAction.OnItemSummon += ResetPosition;
    }

    private void OnDisable()
    {
        _heroAction.OnItemSummon -= ResetPosition;
    }

    private void ResetPosition(Transform heroTransform)
    {
        transform.position = new Vector2(heroTransform.position.x + _basicDistanceToItem, heroTransform.position.y);
    }
}
