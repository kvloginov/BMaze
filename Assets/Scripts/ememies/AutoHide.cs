using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHide : MonoBehaviour
{

    public Transform heroTransform;

    // ищем игрока по имени "hero"
    private Transform thisTransform;

    public float yOffset;
    
    private void Start()
    {
        thisTransform = GetComponent<Transform>();
        
        // скользкая штука 
        heroTransform = GameObject.Find("hero").GetComponent<Transform>();
    }

    void Update()
    {
        if (thisTransform.position.y + yOffset < heroTransform.position.y)
        {
            gameObject.SetActive(false);
        }
    }
}
