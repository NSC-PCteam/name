using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // 最大HP
    private int currentHealth; // 現在のHP

    private void Start()
    {
        currentHealth = maxHealth; // 最初のHPを最大に設定
    }

    // ダメージを受けるメソッド
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // HPを減らす
        Debug.Log("現在のHP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // キャラクターが死ぬときの処理
    private void Die()
    {
        Debug.Log(gameObject.name + " は死んだ！");
        Destroy(gameObject); // オブジェクトを破壊する
    }
}
