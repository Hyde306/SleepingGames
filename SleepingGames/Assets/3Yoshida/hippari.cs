using UnityEngine;

public class hippari : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private Vector2 dragStartPosition;
    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // ���߂͓����Ȃ��悤�ɂ���
        initialPosition = transform.position; // �����ʒu���L�^
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
        }

        if (isDragging)
        {
            Dragging();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }
    }

    private void StartDragging()
    {
        isDragging = true;
        dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Dragging()
    {
        Vector2 currentDragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // �h���b�O�̃r�W���A���t�B�[�h�o�b�N�Ȃǂ�����΂����Ŏ���
    }

    private void StopDragging()
    {
        isDragging = false;
        Vector2 releasePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (dragStartPosition - releasePosition).normalized;
        float distance = Vector2.Distance(dragStartPosition, releasePosition);
        // ��΂��͂̋����𒲐�
        float throwForce = Mathf.Clamp(distance * 10f, 5f, 20f); // �K�X����

        rb.isKinematic = false; // �͂�^���邽�߂ɕ������Z��L����
        rb.AddForce(direction * throwForce, ForceMode2D.Impulse);
        // ��΂�����͏����ʒu�ɖ߂��i�K�v�ɉ����āj
        transform.position = initialPosition;
        rb.velocity = Vector2.zero; // ���x�����Z�b�g
        rb.isKinematic = true; // �ēx�����Ȃ��悤�ɂ���
    }
}