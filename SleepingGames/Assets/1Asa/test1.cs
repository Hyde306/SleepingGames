using UnityEngine;

public class PullController : MonoBehaviour
{
    public GameObject arrow; // 矢印オブジェクト
    private ArrowScaler arrowScaler;
    private Vector3 initialPosition;
    private bool isDragging = false;
    private bool isShooting = false;  // 発射中かどうかを追跡

    void Start()
    {
        arrowScaler = arrow.GetComponent<ArrowScaler>();
        arrow.SetActive(false); // 初期状態で矢印を非表示にする
    }

    void Update()
    {
        if (!isShooting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                initialPosition = transform.position; // 初期位置を更新
                arrow.transform.position = transform.position; // 矢印の位置を初期位置に固定
                arrow.SetActive(true); // 矢印を表示
            }

            if (Input.GetMouseButton(0) && isDragging)
            {
                Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentMousePosition.z = 0; // Z座標を固定

                float pullDistance = Vector3.Distance(initialPosition, currentMousePosition);
                arrowScaler.SetLength(pullDistance); // 矢印の長さを設定

                Vector3 direction = (currentMousePosition - initialPosition).normalized * -1; // 向きを反転
                arrowScaler.SetRotation(direction); // 矢印の回転を設定
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                arrow.SetActive(false); // 矢印を非表示
                isShooting = true;  // 発射中に設定
                arrowScaler.StartShooting();
            }
        }
        else
        {
            arrow.SetActive(false); // 発射中は矢印を非表示
        }

        // テスト用：スペースキー押下で停止
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isShooting = false;  // 発射停止
            arrowScaler.StopShooting();
            Debug.Log("Space key pressed: Velocity set to 0");
        }
    }
}
