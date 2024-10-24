using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Animator animator;
	public bool isRight = true; // Hướng di chuyển của nhân vật
	private Rigidbody2D rb;
	private bool isOnGround = false; // Kiểm tra nếu nhân vật đang trên nền
	public float moveSpeed = 10f; // Tốc độ di chuyển
	public float jumpForce = 17f; // Lực nhảy
	private bool isAttacking = false; // Trạng thái tấn công
	[SerializeField] public GameObject aura;

	// Tham chiếu đến script ManaPlayer
	private ManaPlayer manaPlayer;

	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 3.0f; // Thiết lập trọng lực để rơi nhanh hơn
		manaPlayer = GetComponent<ManaPlayer>(); // Lấy tham chiếu đến ManaPlayer
	}

	void Update()
	{
		bool isMoving = false;

		// Nếu đang tấn công, không cho phép di chuyển
		if (isAttacking)
		{
			rb.velocity = new Vector2(0, rb.velocity.y); // Dừng di chuyển theo trục x
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
			currentVelocity.x = moveSpeed;

			Vector2 scale = transform.localScale;
			scale.x = Mathf.Abs(scale.x); // Đảm bảo nhân vật hướng sang phải
			transform.localScale = scale;
		}
		// Di chuyển sang trái
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			isRight = false;
			animator.SetBool("isRunning", true);
			isMoving = true;
			currentVelocity.x = -moveSpeed;

			Vector2 scale = transform.localScale;
			scale.x = -Mathf.Abs(scale.x); // Đảm bảo nhân vật hướng sang trái
			transform.localScale = scale;
		}
		else
		{
			currentVelocity.x = 0f; // Nếu không di chuyển, dừng lại
		}

		// Nhảy
		if (isOnGround && Input.GetKeyDown(KeyCode.Space))
		{
			currentVelocity.y = jumpForce; // Đặt vận tốc nhảy lên
			animator.SetTrigger("Jump");
			animator.SetBool("isJumping", true);
			isOnGround = false;
		}

		// Tăng tốc độ rơi khi nhân vật rơi
		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (3f - 1) * Time.deltaTime;
		}

		rb.velocity = currentVelocity;

		// Nếu không di chuyển, dừng animation chạy
		if (!isMoving)
		{
			animator.SetBool("isRunning", false);
		}

		// Kiểm tra các hành động tấn công: Punch và Kick
		if (Input.GetKeyDown(KeyCode.J))
		{
			if (!isAttacking)
			{
				isAttacking = true;
				animator.SetBool("isPunch", true); // Bật trạng thái đấm
				Invoke("StopPunch", 0.5f); // Tắt trạng thái đấm sau 0.5 giây
			}
		}
		// Đá (Kick)
		else if (Input.GetKeyDown(KeyCode.K))
		{
			if (!isAttacking)
			{
				isAttacking = true;
				animator.SetBool("isKick", true); // Bật trạng thái đá
				Invoke("StopKick", 0.5f); // Tắt trạng thái đá sau 0.5 giây
			}
		}

		// Kiểm tra trạng thái phòng thủ (bấm giữ D để phòng thủ)
		if (Input.GetKey(KeyCode.DownArrow))
		{
			animator.SetBool("isDefend", true);
		}
		else
		{
			animator.SetBool("isDefend", false);
		}

		// Kiểm tra tăng mana khi bấm phím I
		if (Input.GetKey(KeyCode.I))
		{
			animator.SetBool("isGain", true);
			aura.SetActive(true);
			aura.transform.position = transform.position;
			Debug.Log("Aura position:" + aura.transform.position);
			// Gọi phương thức tăng mana từ ManaPlayer
			manaPlayer.GainMana(5f * Time.deltaTime); // Tăng 5 mana mỗi giây
		}
		else
		{
			animator.SetBool("isGain", false);
			aura.SetActive(false);
		}

		// Kiểm tra mất mana khi bấm phím U hoặc O
		if (Input.GetKeyDown(KeyCode.U))
		{
			manaPlayer.UseMana(10f); // Giảm 10 mana khi bấm U
		}
		else if (Input.GetKeyDown(KeyCode.O))
		{
			manaPlayer.UseMana(10f); // Giảm 10 mana khi bấm O
		}
	}

	// Khi kết thúc va chạm với nền
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			isOnGround = true;
			animator.SetBool("isJumping", false); // Dừng trạng thái nhảy khi tiếp đất
		}
	}

	// Dừng trạng thái đấm
	void StopPunch()
	{
		isAttacking = false;
		animator.SetBool("isPunch", false); // Tắt trạng thái đấm
	}

	// Dừng trạng thái đá
	void StopKick()
	{
		isAttacking = false;
		animator.SetBool("isKick", false); // Tắt trạng thái đá
	}

	// Dừng trạng thái tấn công
	void StopAttacking()
	{
		isAttacking = false;
	}
}
