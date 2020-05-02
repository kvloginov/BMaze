using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Скрипт управляет движением невидимых стен, которые не дают упасть герою в пропасть слева/справа
 * (хацк)
 */
public class MoveCollide : MonoBehaviour
{
    public Transform heroTransform;
    
    private Transform collidebleEdgesTransform;

    private void Start()
    {
        collidebleEdgesTransform = GetComponent<Transform>();
    }

    void Update()
    {
        collidebleEdgesTransform.position = new Vector3(
            collidebleEdgesTransform.position.x,
            heroTransform.position.y,
            0);
    }
}
