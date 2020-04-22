using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using UnityEngine;

public class CollideWithEnemy : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Возможно, эту штуку нужно инвертировать
        if (collision.gameObject.tag == Tags.SIMPLE_ENEMY)
        {
            // ух
            GetComponent<Transform>().position = GetComponent<HeroController>().startPosition;
        }  
    }
}
