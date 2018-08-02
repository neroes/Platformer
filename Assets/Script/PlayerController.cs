using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementModifier;
    public float jumpModifier;
    

    private bool isDead;
    private Rigidbody2D rb;
    private Animator ac;
    private bool isRight = true;
    private Fallthrough fallthrough;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        ac = GetComponent<Animator>();
        fallthrough = GetComponent<Fallthrough>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Move(float Horizontal)
    {
        if (Horizontal != 0.0f)
        {
            Vector2 normal = TraceGround();
            normal = normal == new Vector2(0, 0) ? new Vector2(0, 1) : normal;// sets normal to 0,1 if we didn't hit anything so we can still move, can be modified to lessen air control.

            Vector2 forceVec = new Vector2(normal.y, -normal.x) * Horizontal;
            
            forceVec = Vector2.ClampMagnitude(forceVec, 1) * movementModifier;
            if ((rb.velocity.y >= forceVec.y && forceVec.y >= 0) || (rb.velocity.y >= forceVec.y && forceVec.y < 0) || forceVec.y == 0)
            {// need work to prevent wierd jumping and not jumping
                forceVec += new Vector2(0, rb.velocity.y);
            }
            rb.velocity = forceVec;
            //ac.SetFloat("Running", velocity.magnitude);
            ac.SetFloat("movementSpeed", Horizontal);
            if ((rb.velocity.x > 0) != isRight)
            {
                Flip();
            }
        }        
    }
    public void FallThrough()
    {
        fallthrough.enabled = true;
        fallthrough.ResetTimer();
        
    }
    public void Jump()
    {
        Vector2 normal = TraceGround();
        if (normal != new Vector2(0f, 0f))
        {
            Vector2 forceVec = jumpModifier * new Vector2(0f, 1f)+ new Vector2(rb.velocity.x,0);
            rb.velocity = forceVec;
        }
        // needs an time out event in case the box is stuck floating
    }
    public void ForceJump()
    {
        Vector2 forceVec = jumpModifier * new Vector2(0f, 1f);
        rb.velocity *= new Vector2(1f, 0f);
        rb.velocity += forceVec;
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            ac.SetTrigger("die");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    private Vector2 TraceGround()// returns the first object that is from the map layer(9) at a max distance of 1.54 from player center(player center is 1 from the bottom and 0.5 is needed for 45 degree angle, with a little buffer becomes 1.54)
    {
        
        RaycastHit2D r = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.54f, (int)GameManager.EasyLayers.GroundLayer);
        Vector2 v = r.normal;
        if (fallthrough.enabled) {
            if (v == new Vector2(0, 0))
            {
                return v;
            }
            else if (r.collider.tag == "OneWay")
            {
                return new Vector2(0,0);
            }
        }
        return v;
    }
    private void Flip()
    {
        Vector3 scale = transform.localScale;// flipping whole object
        scale.x *= -1;
        transform.localScale = scale;

        isRight = isRight ? false : true;
    }
}
