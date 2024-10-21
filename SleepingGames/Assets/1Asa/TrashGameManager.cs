using UnityEngine;

public class TrashGameManager : MonoBehaviour
{
    public GameObject trashObject; // �S�~�I�u�W�F�N�g
    public float resetTime = 5.0f;  // �S�~���~�܂��Ă��烊�Z�b�g����܂ł̎���
    public Vector3 initialPosition; // �S�~�̏����ʒu

    private Rigidbody trashRigidbody;
    private bool isTrashStopped = false;
    private float timer = 0f;

    void Start()
    {
        trashRigidbody = trashObject.GetComponent<Rigidbody>();
        initialPosition = trashObject.transform.position; // �����ʒu��ۑ�
    }

    void Update()
    {
        // �S�~�������Ă��Ȃ����ǂ������`�F�b�N
        if (trashRigidbody.IsSleeping() && !isTrashStopped)
        {
            isTrashStopped = true;
            timer = resetTime;
        }

        if (isTrashStopped)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ResetTrashPosition();
            }
        }
    }

    void ResetTrashPosition()
    {
        trashObject.transform.position = initialPosition; // �����ʒu�ɖ߂�
        trashRigidbody.velocity = Vector3.zero; // ���x�����Z�b�g
        trashRigidbody.angularVelocity = Vector3.zero; // ��]���x�����Z�b�g
        isTrashStopped = false; // ���Z�b�g�t���O������
    }
}
