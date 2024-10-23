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
        if (Input.GetKey(KeyCode.U) && coolDownTimer > attackCoolDown)
        {
            AttackSkill1();

        }
        if (Input.GetKey(KeyCode.I) && coolDownTimer > attackCoolDown)
        {
            AttackSkill2();

        }
        coolDownTimer += Time.deltaTime;
    }

    private void AttackSkill1()
    {
        animator.SetTrigger("Skill1");
        coolDownTimer = 0;

    }

    private void AttackSkill2()
    {
        animator.SetTrigger("Skill2");
        coolDownTimer = 0;

    }



}
