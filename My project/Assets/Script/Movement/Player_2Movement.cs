using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2Movement : MonoBehaviour
{
    public Animator animator;
    public bool isRight = true;
    private Rigidbody2D rb;
    private bool isFighting = false; // Biến kiểm tra trạng thái đánh nhau
    private bool isAttack = false; // Biến kiểm tra trạng thái tấn công

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Thiết lập trọng lực để rơi nhanh hơn
        rb.gravityScale = 3.0f;
    }

    void Update()
    {
        bool isMoving = false;

        // Kiểm tra nếu đang đánh nhau hoặc đang tấn công, không cho di chuyển
        if (isFighting || isAttack)
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Dừng chỉ theo trục x, giữ nguyên trục y (để nhảy)
            return;
        }

        // Lấy vận tốc hiện tại của Rigidbody2D
        Vector2 currentVelocity = rb.velocity;

        // Di chuyển sang phải
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            animator.SetBool("isRunning", true);
            isMoving = true;
            currentVelocity.x = 5f;

            Vector2 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        // Di chuyển sang trái
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;
            animator.SetBool("isRunning", true);
            isMoving = true;
            currentVelocity.x = -5f;

            Vector2 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else
        {
            currentVelocity.x = 0f;
        }

        // Nhảy
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentVelocity.y = 10f; // Đặt vận tốc nhảy lên
            animator.SetTrigger("Jump");
            animator.SetBool("isJumping", true);
            Debug.Log("Jump Triggered!");
        }

        // Kiểm tra nếu nhân vật đang rơi
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (3f - 1) * Time.deltaTime; // Tăng tốc độ rơi
        }

        rb.velocity = currentVelocity;

        if (!isMoving)
        {
            animator.SetBool("isRunning", false);
        }

        // Kiểm tra đánh nhau
        if (Input.GetKeyDown(KeyCode.K)) // Kiểm tra nhấp chuột trái
        {
            if (!isAttack) // Nếu chưa tấn công thì cho phép tấn công
            {
                isAttack = true;
                animator.SetBool("isAttack", true); // Kích hoạt animation tấn công
                Invoke("StopAttacking", 0.5f); // Dừng trạng thái tấn công sau 0.5 giây
            }
        }
    }

    // Khi kết thúc va chạm với nền
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isJumping", false); // Dừng trạng thái nhảy khi tiếp đất
        }
    }

    // Dừng trạng thái tấn công
    void StopAttacking()
    {
        isAttack = false;
        animator.SetBool("isAttack", false);
    }
}
