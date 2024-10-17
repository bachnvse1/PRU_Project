using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Animator animator;
	public bool isRight = true;
	private Rigidbody2D rb;
	private bool nen;
	public float moveSpeed = 10f; // Tốc độ di chuyển
	public float jumpForce = 17f; // Lực nhảy


	private bool isAttacking = false; // Biến để theo dõi trạng thái tấn công

	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

		// Thiết lập trọng lực để rơi nhanh hơn
		rb.gravityScale = 3.0f;
	}

	void Update()
	{
		// Kiểm tra trạng thái tấn công, nếu đang tấn công thì không cho di chuyển
		if (!isAttacking)
		{
			// Di chuyển sang phải
			if (Input.GetKey(KeyCode.RightArrow))
			{
				isRight = true;
				animator.SetBool("isRunning", true);
				Vector2 currentVelocity = rb.velocity;
				currentVelocity.x = moveSpeed;
				rb.velocity = currentVelocity;

				Vector2 scale = transform.localScale;
				scale.x = Mathf.Abs(scale.x);
				transform.localScale = scale;
			}
			// Di chuyển sang trái
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				isRight = false;
				animator.SetBool("isRunning", true);
				Vector2 currentVelocity = rb.velocity;
				currentVelocity.x = -moveSpeed;
				rb.velocity = currentVelocity;

				Vector2 scale = transform.localScale;
				scale.x = -Mathf.Abs(scale.x);
				transform.localScale = scale;
			}
			else
			{
				animator.SetBool("isRunning", false);
				Vector2 currentVelocity = rb.velocity;
				currentVelocity.x = 0f;
				rb.velocity = currentVelocity;
			}

			// Nhảy
			if (nen && Input.GetKeyDown(KeyCode.Space))
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Đặt vận tốc nhảy lên
				animator.SetBool("isJumping", true);
				nen = false;
			}

			// Kiểm tra nếu nhân vật đang rơi
			if (rb.velocity.y < 0)
			{
				rb.velocity += Vector2.up * Physics2D.gravity.y * (3f - 1) * Time.deltaTime; // Tăng tốc độ rơi
			}

			// Kiểm tra trạng thái phòng thủ (bấm giữ D để phòng thủ)
			if (Input.GetKey(KeyCode.D))
			{
				animator.SetBool("isDefend", true);
			}
			else
			{
				animator.SetBool("isDefend", false); 
			}
			if (Input.GetKey(KeyCode.U))
			{
				animator.SetBool("isGain", true);
			}
			else
			{
				animator.SetBool("isGain", false); 
			}

			// Kiểm tra trạng thái đá
			if (Input.GetKeyDown(KeyCode.J))
			{
				animator.SetBool("isKick", true);
			}
			else
			{
				animator.SetBool("isKick", false);
			}

			if (Input.GetKeyDown(KeyCode.F))
			{
				animator.SetBool("isPunch", true);
			}
			else
			{
				animator.SetBool("isPunch", false);
			}
		}
	}

	// Khi kết thúc va chạm với nền
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			nen = true;
			animator.SetBool("isJumping", false); // Dừng trạng thái nhảy khi tiếp đất
		}
	}
}
