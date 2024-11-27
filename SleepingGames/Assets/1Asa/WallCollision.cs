using UnityEngine;
using Cinemachine;

public class WallCollision : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;


    private void Start()
    {
        var s = GetComponent<Cinemachine.CinemachineImpulseSource>();
        s.GenerateImpulse();

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("yure"); // さらに詳細なデバッグメッセージ
        Debug.Log("Collision detected with: " + collision.gameObject.name); // 衝突検出のデバッグメッセージ
        if (collision.gameObject.CompareTag("gomi"))
        {
     
        }
    }
}
