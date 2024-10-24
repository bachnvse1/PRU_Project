﻿using UnityEngine;

public class PlayerAttackFireball : MonoBehaviour
{
	[SerializeField] private float attackCooldown;
	[SerializeField] private Transform firePoint;
	[SerializeField] private GameObject fireballPrefab; // Thêm prefab của Fireball

	private Animator anim;
	private float cooldownTimer = Mathf.Infinity;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.K) && cooldownTimer > attackCooldown)
			Attack();
		

		cooldownTimer += Time.deltaTime;
	}

	private void Attack()
	{
		cooldownTimer = 0;
		anim.SetTrigger("attack_fireball");
		Debug.Log("Fireball Attack Triggered");

		// Tạo mới một Fireball từ prefab tại vị trí firePoint
		GameObject newFireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

		// Gọi hàm SetDirection để thiết lập hướng cho Fireball
		newFireball.GetComponent<Fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
		Debug.Log("Fireball Created at: " + firePoint.position);
	}
}