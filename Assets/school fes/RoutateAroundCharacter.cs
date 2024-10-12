using UnityEngine;

public class RotateObjectAroundCharacter : MonoBehaviour
{
    // キャラクターのTransform
    public Transform character;

    // 小物のTransform
    public Transform objectToRotate;

    // 回転速度
    public float rotationSpeed = 50f;

    // 小物の両端とキャラクターの距離
    public float distanceFromCharacter = 2f;

    // 回転角度の合計
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

            // 小物をキャラクターの周りに回転させる
            objectToRotate.RotateAround(character.position, Vector3.up, rotationStep);

            // 回転した角度を加算
            currentRotation += -rotationStep;

            // 1周（360度）したら回転を止める
            if (currentRotation >= 360f)
            {
                startRotation = false; // 回転終了
            }
        }

        // 小物の位置をキャラクターからの距離に応じて調整
        Vector3 direction = (objectToRotate.position - character.position).normalized;
        objectToRotate.position = character.position + direction * distanceFromCharacter;
    }
}
