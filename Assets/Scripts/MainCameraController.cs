using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{

    public GameObject hero;

    private Vector3 offset;

    private Camera thisCamera;

    private Rect startRectInWolrd;

    void Start()
    {
        thisCamera = GetComponent<Camera>();

        var oldPos = transform.position;
        transform.position = new Vector3(0, 0, 0);
        Vector2 bottomLeftCorner = thisCamera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRightCorner = thisCamera.ViewportToWorldPoint(new Vector2(1, 1));
        transform.position = oldPos;
        startRectInWolrd = new Rect(bottomLeftCorner, topRightCorner - bottomLeftCorner);

        // будем оставлять такой же offset как в начале игры
        offset = transform.position - hero.transform.position;
    }

    
    void Update()
    {
        transform.position = hero.transform.position + offset;
    }

    public Rect GetViewRectInWorld()
    {
        return new Rect(startRectInWolrd.min + (Vector2)transform.position, startRectInWolrd.size);
    }
}
