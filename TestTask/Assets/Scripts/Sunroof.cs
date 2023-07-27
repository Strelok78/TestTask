using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunroof : MonoBehaviour
{
    private void Open()
    {
        transform.Translate(Vector2.left * Time.deltaTime);
    }
}
