using UnityEngine;

public class ArrowScaler : MonoBehaviour
{
    public float maxLength = 3.0f; // 最大長さ
    public float minLength = 0.0f; // 最小長さ
    private bool isShooting = false; // 発射中かどうかを追跡

    public void SetLength(float length)
    {
        if (!isShooting)
        {
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Clamp(length, minLength, maxLength);
            transform.localScale = scale;
        }
    }

    public void SetRotation(Vector3 direction)
    {
        if (!isShooting)
        {
            transform.up = direction; // 矢印の向きを設定
        }
    }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }
}
