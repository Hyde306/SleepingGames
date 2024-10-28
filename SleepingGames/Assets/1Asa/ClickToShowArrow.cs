using UnityEngine;

public class ClickToShowArrow : MonoBehaviour
{
    public GameObject arrowPrefab; // 矢印のプレハブ
    private GameObject arrowInstance; // 矢印のインスタンス
    private ArrowScaler arrowScaler;
    private Vector3 initialPosition;
    private bool isDragging = false;
    private bool isShooting = false;  // 発射中かどうかを追跡

    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // Z座標を固定

                // 矢印のインスタンスを生成
                arrowInstance = Instantiate(arrowPrefab, mousePosition, Quaternion.identity);
                arrowScaler = arrowInstance.GetComponent<ArrowScaler>();

                isDragging = true;
                initialPosition = mousePosition;
                arrowInstance.SetActive(true); // 矢印を表示
            }

            if (Input.GetMouseButton(0) && isDragging)
            {
                Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentMousePosition.z = 0; // Z座標を固定

                float pullDistance = Vector3.Distance(initialPosition, currentMousePosition);
                arrowScaler.SetLength(pullDistance); // 矢印の長さを設定

                // 矢印の向きを設定
                Vector3 direction = (initialPosition - currentMousePosition).normalized;
                arrowScaler.SetRotation(direction); // 矢印の回転を設定
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                isDragging = false;
                arrowInstance.SetActive(false); // 矢印を非表示
            }
 
      // テスト用：スペースキー押下で停止
        if (Input.GetKeyDown(KeyCode.Space))
        {
  
            isShooting = false;  // 発射停止
            arrowScaler.StopShooting();
            Debug.Log("Space key pressed: Velocity set to 0");
        }
    }
}