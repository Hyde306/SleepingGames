using UnityEngine;

public class hanabi : MonoBehaviour
{
    public ParticleSystem firework;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gomibako"))
        {
            Debug.Log("�S�~���ڐG���܂����I");
            if (firework != null)
            {
                firework.Stop();  // �܂��p�[�e�B�N���V�X�e�����~���܂�
                firework.Play();  // ���̌�ēx�Đ����܂�
            }
        }
    }
}
