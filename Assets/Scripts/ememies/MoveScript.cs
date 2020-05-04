using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveScript : MonoBehaviour
{
    const float SEC_IN_MINUTE = 60;

    [Range(-30, 30)]
    public float rotationsPerSecond;

    [Range(0, 30)]
    public float moveSpeed;

    public MoveDirection moveDirection;

    private void FixedUpdate()
    {
        if (moveDirection.Equals(MoveDirection.Left)) 
        {
            transform.position += new Vector3(-moveSpeed * Time.fixedDeltaTime, 0, 0);
        } 
        else if (moveDirection.Equals(MoveDirection.Right)) 
        {
            transform.position += new Vector3(moveSpeed * Time.fixedDeltaTime, 0, 0);
        }
        else if (moveDirection.Equals(MoveDirection.Down))
        {
            transform.position += new Vector3(0, -moveSpeed * Time.fixedDeltaTime, 0);
        }

        transform.Rotate(0, 0, rotationsPerSecond * Time.fixedDeltaTime * SEC_IN_MINUTE, Space.Self);
    }
}
