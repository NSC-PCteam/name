using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int damage = 10; // 与えるダメージ量

    // トリガーに接触したときに呼び出されるメソッド
    private void OnTriggerEnter(Collider other)
    {
        // 接触したオブジェクトがHealthSystemを持っているか確認
        HealthSystem healthSystem = other.GetComponent<HealthSystem>();

        if (healthSystem != null)
        {
            // プレイヤーにダメージを与える
            healthSystem.TakeDamage(damage);
            Debug.Log(other.gameObject.name + " に " + damage + " のダメージを与えた！");
        }
    }
}
