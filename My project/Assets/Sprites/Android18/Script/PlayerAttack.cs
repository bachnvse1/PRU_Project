using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] private float attackCooldown;
	[SerializeField] private Transform firePoint;
	[SerializeField] private GameObject[] fireballs;

	private Animator anim;
	private PlayerMovement playerMovement;
	private float cooldownTimer = Mathf.Infinity;
	private bool isAttacking = false; // Biến để theo dõi trạng thái tấn công

	private void Awake()
	{
		anim = GetComponent<Animator>();
		playerMovement = GetComponent<PlayerMovement>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.K) && cooldownTimer > attackCooldown && !isAttacking)
		{
			FireballAttack();
		}

		cooldownTimer += Time.deltaTime;
	}

	private void FireballAttack()
	{
		isAttacking = true; // Bắt đầu tấn công
		anim.SetBool("isKame", true); // Kích hoạt animation
		cooldownTimer = 0; // Đặt lại thời gian hồi chiêu

		// Tìm fireball chưa được kích hoạt
		int fireballIndex = FindFireball();
		fireballs[fireballIndex].transform.position = firePoint.position; // Đặt vị trí fireball tại firePoint
		fireballs[fireballIndex].GetComponent<Fireball>().SetDirection(Mathf.Sign(transform.localScale.x)); // Đặt hướng cho fireball

		// Đặt thời gian để kiểm tra khi nào animation kết thúc
		Invoke("FinishAttack", 0.4f); // Thay đổi giá trị 0.5f cho phù hợp với thời gian animation
	}

	private int FindFireball()
	{
		for (int i = 0; i < fireballs.Length; i++)
		{
			if (!fireballs[i].activeInHierarchy)
				return i;
		}
		return 0;
	}

	private void FinishAttack()
	{
		anim.SetBool("isKame", false); // Tắt animation
		isAttacking = false; // Kết thúc tấn công
	}
}
