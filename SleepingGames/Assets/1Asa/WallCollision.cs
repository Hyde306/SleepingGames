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
        Debug.Log("yure"); // ����ɏڍׂȃf�o�b�O���b�Z�[�W
        Debug.Log("Collision detected with: " + collision.gameObject.name); // �Փˌ��o�̃f�o�b�O���b�Z�[�W
        if (collision.gameObject.CompareTag("gomi"))
        {
     
        }
    }
}
