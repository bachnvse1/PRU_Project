using UnityEngine;

public class PlayerAttackKamehameha : MonoBehaviour
{
	[SerializeField] private float attackCooldown;
	[SerializeField] private Transform firePoint; // Sử dụng firePoint để Kamehameha xuất phát từ đây
	[SerializeField] private GameObject kamePrefab; // Prefab của Kamehameha

	private Animator anim;
	private float cooldownTimer = Mathf.Infinity;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.O) && cooldownTimer > attackCooldown)
			Attack();

		cooldownTimer += Time.deltaTime;
	}

	private void Attack()
	{
		cooldownTimer = 0;
		anim.SetTrigger("attack_kame");
		Debug.Log("Kamehameha Attack Triggered");

		// Tạo mới một Kamehameha từ prefab tại vị trí firePoint
		GameObject newKame = Instantiate(kamePrefab, firePoint.position, firePoint.rotation);

		// Gọi hàm SetDirection để thiết lập hướng cho Kamehameha dựa trên hướng của nhân vật
		newKame.GetComponent<Kamehameha>().SetDirection(Mathf.Sign(transform.localScale.x));
		Debug.Log("Kamehameha Created at: " + firePoint.position);
	}
}
