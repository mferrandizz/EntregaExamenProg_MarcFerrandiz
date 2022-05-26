using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    
    public Transform target; 
    public Vector3 offset;

    public Vector2 limitX;
    public Vector2 limitY;

    public float interpolationRatio;
    


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        float limitedXPosition = Mathf.Clamp(desiredPosition.x, limitX.x, limitX.y);
        float limitedYPosition = Mathf.Clamp(desiredPosition.y, limitY.x, limitY.y);
        Vector3 limitedPosition = new Vector3(limitedXPosition, limitedYPosition, desiredPosition.z);
        Vector3 lerpedPosition = Vector3.Lerp(transform.position, limitedPosition, interpolationRatio);

        transform.position = lerpedPosition;



    }
}
