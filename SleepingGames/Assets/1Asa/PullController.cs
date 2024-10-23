using UnityEngine;

public class PullController : MonoBehaviour

{

    public GameObject arrow; // ���I�u�W�F�N�g

    private ArrowScaler arrowScaler;

    private Vector3 initialPosition;

    private bool isDragging = false;

    void Start()

    {

        arrowScaler = arrow.GetComponent<ArrowScaler>();

        arrow.SetActive(false); // ������ԂŖ����\���ɂ���

    }

    void Update()

    {

        if (Input.GetMouseButtonDown(0))

        {

            isDragging = true;

            initialPosition = transform.position;

            arrow.transform.position = transform.position; // ������������Ώۂ̈ʒu�ɐݒ�

            arrow.SetActive(true); // ����\��

        }

        if (Input.GetMouseButton(0) && isDragging)

        {

            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            currentMousePosition.z = 0; // Z���W���Œ�

            float pullDistance = Vector3.Distance(initialPosition, currentMousePosition);

            arrowScaler.SetLength(pullDistance); // ���̒�����ݒ�

            // ���̌�����ݒ�

            Vector3 direction = (initialPosition - currentMousePosition).normalized;

            arrowScaler.SetRotation(direction); // ���̉�]��ݒ�

        }

        if (Input.GetMouseButtonUp(0))

        {

            isDragging = false;

            arrow.SetActive(false); // �����\��

        }

    }

}
