using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{

    public GameObject hero;

    private Vector3 offset;

    void Start()
    {
        // будем оставлять такой же offset как в начале игры
        offset = transform.position - hero.transform.position;
    }

    
    void Update()
    {
        transform.position = hero.transform.position + offset;
    }
}
