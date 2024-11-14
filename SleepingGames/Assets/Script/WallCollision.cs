using UnityEngine;
using Cinemachine;

public class WallCollision : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // �Փˌ��o�̃f�o�b�O���b�Z�[�W
        if (collision.gameObject.CompareTag("gomi"))
        {
            Debug.Log("Collision with gomi detected"); // ����ɏڍׂȃf�o�b�O���b�Z�[�W
            impulseSource.GenerateImpulse();
        }
    }
}
