using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWorldMap : MonoBehaviour {

    public float movementModifier;

    private bool isRight;
    private Rigidbody2D rb;
    private Animator ac;

    private void Start()
    {
        //ac = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    public void Move(float Horizontal, float Vertical)
    {
        //Vector2 forceVec = new Vector2(Horizontal * movementModifier,Vertical *movementModifier);
        //rb.AddForce(forceVec);
        Vector3 velocity = Vector3.ClampMagnitude(new Vector3(Horizontal, Vertical, 0), 1) * movementModifier;
        rb.velocity = velocity;
        
        //ac.SetFloat("HorizontalSpeed", Horizontal);
        //ac.SetFloat("VerticalSpeed", Vertical);
    }
    private void Flip()
    {
        Vector3 scale = transform.localScale;// flipping whole object
        scale.x *= -1;
        transform.localScale = scale;

        isRight = isRight ? false : true;
    }
}
