using UnityEngine;
using Cinemachine;

public class WallCollision : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // 衝突検出のデバッグメッセージ
        if (collision.gameObject.CompareTag("gomi"))
        {
            Debug.Log("Collision with gomi detected"); // さらに詳細なデバッグメッセージ
            impulseSource.GenerateImpulse();
        }
    }
}
