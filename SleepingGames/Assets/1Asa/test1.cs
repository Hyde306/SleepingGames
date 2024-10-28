using UnityEngine;

public class PullController : MonoBehaviour
{
    public GameObject arrow; // ���I�u�W�F�N�g
    private ArrowScaler arrowScaler;
    private Vector3 initialPosition;
    private bool isDragging = false;
    private bool isShooting = false;  // ���˒����ǂ�����ǐ�

    void Start()
    {
        arrowScaler = arrow.GetComponent<ArrowScaler>();
        arrow.SetActive(false); // ������ԂŖ����\���ɂ���
    }

    void Update()
    {
        if (!isShooting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                initialPosition = transform.position; // �����ʒu���X�V
                arrow.transform.position = transform.position; // ���̈ʒu�������ʒu�ɌŒ�
                arrow.SetActive(true); // ����\��
            }

            if (Input.GetMouseButton(0) && isDragging)
            {
                Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentMousePosition.z = 0; // Z���W���Œ�

                float pullDistance = Vector3.Distance(initialPosition, currentMousePosition);
                arrowScaler.SetLength(pullDistance); // ���̒�����ݒ�

                Vector3 direction = (currentMousePosition - initialPosition).normalized * -1; // �����𔽓]
                arrowScaler.SetRotation(direction); // ���̉�]��ݒ�
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                arrow.SetActive(false); // �����\��
                isShooting = true;  // ���˒��ɐݒ�
                arrowScaler.StartShooting();
            }
        }
        else
        {
            arrow.SetActive(false); // ���˒��͖����\��
        }

        // �e�X�g�p�F�X�y�[�X�L�[�����Œ�~
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isShooting = false;  // ���˒�~
            arrowScaler.StopShooting();
            Debug.Log("Space key pressed: Velocity set to 0");
        }
    }
}
