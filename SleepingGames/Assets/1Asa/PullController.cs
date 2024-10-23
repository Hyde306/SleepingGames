using UnityEngine;

public class PullController : MonoBehaviour

{

    public GameObject arrow; // 矢印オブジェクト

    private ArrowScaler arrowScaler;

    private Vector3 initialPosition;

    private bool isDragging = false;

    void Start()

    {

        arrowScaler = arrow.GetComponent<ArrowScaler>();

        arrow.SetActive(false); // 初期状態で矢印を非表示にする

    }

    void Update()

    {

        if (Input.GetMouseButtonDown(0))

        {

            isDragging = true;

            initialPosition = transform.position;

            arrow.transform.position = transform.position; // 矢印を引っ張る対象の位置に設定

            arrow.SetActive(true); // 矢印を表示

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

        if (Input.GetMouseButtonUp(0))

        {

            isDragging = false;

            arrow.SetActive(false); // 矢印を非表示

        }

    }

}
