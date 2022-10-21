using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private float moveH; //horizontal hareket
    [SerializeField]
    private float horizontalLimit;//sahneden dýþarý çýkmamasý için
    [SerializeField]
    private float horizontalmoveSpeed;
    [SerializeField]
    private float forwardMoveSpeed;


    void Update()
    {
        if(Input.touchCount > 0)
        {
            HorizantalMove();
        }
        ForwardMove();
    }

    private void HorizantalMove()
    {
        float newX;

        moveH = Input.touches[0].deltaPosition.x;

        newX = transform.position.x + moveH * horizontalmoveSpeed * Time.deltaTime;
        newX = Mathf.Clamp(newX, -horizontalLimit, horizontalLimit);

        transform.position = new Vector3(newX,transform.position.y,transform.position.z);
    }

    private void ForwardMove()
    {
        transform.Translate(forwardMoveSpeed * Time.deltaTime * Vector3.forward);
    }
}
