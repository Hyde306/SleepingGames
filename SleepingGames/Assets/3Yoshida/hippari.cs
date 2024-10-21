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
        rb.isKinematic = true; // 初めは動かないようにする
        initialPosition = transform.position; // 初期位置を記録
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
        // ドラッグのビジュアルフィードバックなどがあればここで実装
    }

    private void StopDragging()
    {
        isDragging = false;
        Vector2 releasePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (dragStartPosition - releasePosition).normalized;
        float distance = Vector2.Distance(dragStartPosition, releasePosition);
        // 飛ばす力の強さを調整
        float throwForce = Mathf.Clamp(distance * 10f, 5f, 20f); // 適宜調整

        rb.isKinematic = false; // 力を与えるために物理演算を有効化
        rb.AddForce(direction * throwForce, ForceMode2D.Impulse);
        // 飛ばした後は初期位置に戻す（必要に応じて）
        transform.position = initialPosition;
        rb.velocity = Vector2.zero; // 速度をリセット
        rb.isKinematic = true; // 再度動かないようにする
    }
}