using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSkill : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private PlayerMovement playerMovement;
    private Animator animator;
    private float coolDownTimer = Mathf.Infinity;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && coolDownTimer > attackCoolDown)
        {
            Attack();

        }
        coolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("Skill1");
        coolDownTimer = 0;

    }

   

}
