using System.Collections;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public Animator animator;
    public float comboResetTime = 1f; // Thời gian để reset combo
    public float comboDelay = 0.5f;   // Khoảng thời gian giữa mỗi đòn combo

    private bool isComboActive = false; // Biến kiểm tra xem combo có đang diễn ra không

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Khi nhấn phím J, thực hiện attack cơ bản
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
            animator.SetTrigger("Idle");
        }

        // Khi nhấn phím C, thực hiện combo ba đòn
        if (Input.GetKeyDown(KeyCode.C) && !isComboActive)
        {
            StartCoroutine(PerformCombo());
        }
    }

    void Attack()
    {
        // Trigger animation attack cơ bản
        animator.SetTrigger("Attack1");
   
    }

    IEnumerator PerformCombo()
    {
        isComboActive = true;

        // Đòn combo thứ nhất
        animator.SetTrigger("Attack1");
        yield return new WaitForSeconds(comboDelay); // Chờ trước khi thực hiện đòn tiếp theo

        // Đòn combo thứ hai
        animator.SetTrigger("Attack2");
        yield return new WaitForSeconds(comboDelay);

        // Đòn combo thứ ba
        animator.SetTrigger("Attack3");
        yield return new WaitForSeconds(comboDelay);
        animator.SetTrigger("Idle");

        isComboActive = false; // Kết thúc combo
    }
}
