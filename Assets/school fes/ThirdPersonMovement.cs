using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;  // キャラクターコントローラー
    public Transform cam;  // カメラのTransform
    public float speed = 6f;  // キャラクターの移動速度
    public float turnSmoothTime = 0.1f;  // キャラクターの回転のスムーズさ
    private float turnSmoothVelocity;

    void Update()
    {
        // 移動入力の取得
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // カメラに基づいてキャラクターの向きを回転させる
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // カメラの向きに基づいて移動させる
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
