using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;

public static class TouchController
{
       public static Vector2 GetMoveVector(Vector2 controllerCenter)
    {
#if UNITY_STANDALONE
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#elif UNITY_IOS || UNITY_ANDROID
        // Просто для проверки на компе при включеном touch-режиме
        if (Input.GetMouseButton((int)MouseButton.LeftMouse)){
            var mousePos = (Vector2)Input.mousePosition;
            var moveVector = mousePos - controllerCenter;
            return moveVector;
        }
        
        if (Input.touchCount > 0)
        {
            var touchPos = Input.GetTouch(0).position;
            var moveVector = touchPos - controllerCenter;
            return moveVector;

        }

        return new Vector2(0, 0);
#endif
    }
}
