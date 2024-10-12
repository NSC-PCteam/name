using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Animatorコンポーネントを参照する変数
    private Animator animator;

    void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Enterキーを検出
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Attackモーションを再生するためにTriggerを発動
            animator.SetTrigger("Attack");
        }
    }
}
