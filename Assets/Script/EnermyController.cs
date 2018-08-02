using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyController : MonoBehaviour {
    private bool isAlive;
    private Animator ac;
    private Rigidbody2D rb;
    private Vector3 movementVec;
    private GameObject playerCollider;
    public GameObject SetPlayerCollider { set { playerCollider = value; } }

    public float width;
    public float movementSpeed;
    private void Start()
    {
        movementVec = new Vector3(movementSpeed, 0, 0);
        isAlive = true;
        ac = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!ReachedEdge())
        {
            movementVec *= -1f;
        }
        rb.velocity = movementVec;
    }
    private bool ReachedEdge()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(width/2 * Mathf.Abs(rb.velocity.x)/rb.velocity.x,0)+ transform.position, new Vector2(0, -1), 1.6f, (int)GameManager.EasyLayers.GroundEvenLayer);
        return (hit.collider != null);
    }
    public void Smush(Collider2D collision)
    {
        if (isAlive)
        {
            ac.SetTrigger("die");
            collision.GetComponent<PlayerController>().ForceJump();
            isAlive = false;
        }
        rb.velocity = new Vector3(0,0);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        playerCollider.SetActive(false);
    }
    
}
