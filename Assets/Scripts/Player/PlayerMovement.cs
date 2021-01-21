using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private float Horizontal;
    private float Vertical;
    private float Speed;

    public PlayerMovement(float playerSpeed)
    {
        Speed = playerSpeed;
    }


    public void InputLimit()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (Horizontal != 0 && Vertical != 0)
        {
            Horizontal *= 0.75f;
            Vertical *= 0.75f;
        }
    }



    public void Moving(Rigidbody2D playerRigidbody)
    {
        playerRigidbody.velocity = new Vector2(Horizontal * Speed, Vertical * Speed);
    }



    public void RotateToMouse(Transform playerTransform)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookAt = mousePos;

        float AngleRad = Mathf.Atan2(lookAt.y - playerTransform.position.y, lookAt.x - playerTransform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        playerTransform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
