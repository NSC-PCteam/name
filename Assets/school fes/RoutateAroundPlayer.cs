using UnityEngine;

public class RotateAroundPlayerOnce : MonoBehaviour
{
    // プレイヤーのTransform（プレイヤーの位置を取得するため）
    public Transform player;

    // 小物が回転する速度
    public float rotationSpeed = 100f;

    // 回転角度の合計（プレイヤーの周りを1周させるために使用）
    private float currentRotation = 0f;

    // 回転を開始するフラグ
    private bool startRotation = false;

    void Update()
    {
        // エンターキーが押されたら回転を開始する
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!startRotation)
            {
                startRotation = true;
                currentRotation = 0f; // 回転角度のリセット
            }
        }

        // 回転が開始されていて、まだ1周していない場合
        if (startRotation && currentRotation < 360f)
        {
            // 回転角度を計算
            float rotationStep = -rotationSpeed * Time.deltaTime;

            // 小物がプレイヤーの周りを回転する
            transform.RotateAround(player.position, Vector3.up, rotationStep);

            // 回転した角度を加算
            currentRotation += -rotationStep;

            // 1周（360度）したら回転を止める
            if (currentRotation >= 360f)
            {
                startRotation = false; // 回転終了
            }
        }
    }
}

