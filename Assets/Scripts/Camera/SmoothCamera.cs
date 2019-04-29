using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector2 maxPos;
    public Vector2 minPos;

    void OnLevelWasLoaded(int index)
    {
        this.transform.position = PlayerStats.playerCoords + offset;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        //desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPos.x, maxPos.x);
        //desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPos.y, maxPos.y);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
