using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollower : MonoBehaviour
{
    public Transform targetHand;  // キャラクターの手に相当するTransform
    public Vector3 offsetPosition;  // 手との相対的な位置
    public Vector3 offsetRotation;  // 手との相対的な回転

    void Update()
    {
        // 手の位置と回転に追従
        transform.position = targetHand.position + offsetPosition;
        transform.rotation = targetHand.rotation * Quaternion.Euler(offsetRotation);
    }
}
