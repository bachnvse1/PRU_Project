using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    private Rigidbody2D rigid;
    private Animator animator;
    private bool Grounded;
    float horizontalinput;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(horizontalinput * speed, rigid.velocity.y);

        if (horizontalinput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalinput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && Grounded) Jump();

        animator.SetBool("Grounded", Grounded);
        animator.SetBool("run", horizontalinput != 0);
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, speed);
        animator.SetTrigger("Jump");
        Grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Ground"))
        {
            Grounded = true;
        }
    }

}
