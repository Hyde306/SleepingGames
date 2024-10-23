using UnityEngine;

public class ArrowScaler : MonoBehaviour
{
    public float maxLength = 3.0f; // �ő咷��
    public float minLength = 0.5f; // �ŏ�����

    public void SetLength(float length)
    {
        Vector3 scale = transform.localScale;
        scale.y = Mathf.Clamp(length, minLength, maxLength);
        transform.localScale = scale;
    }

    public void SetRotation(Vector3 direction)
    {
        transform.up = direction; // ���̌�����ݒ�
    }
}
