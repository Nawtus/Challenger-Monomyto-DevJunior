using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement
{
    private float Speed;

    public BotMovement(float botSpeed)
    {
        Speed = botSpeed;
    }



    public void Chasing(Transform target, Transform botTransform)
    {
        botTransform.position = Vector2.MoveTowards(botTransform.position, target.position, Speed * Time.deltaTime);
    }



    public void RotateTo(Vector3 target,Transform botTransform)
    {
        float AngleRad = Mathf.Atan2(target.y - botTransform.position.y, target.x - botTransform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        botTransform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
