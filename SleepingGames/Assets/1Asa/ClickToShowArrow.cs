using UnityEngine;

public class ClickToShowArrow : MonoBehaviour
{
    public GameObject arrowPrefab; // ���̃v���n�u
    private GameObject arrowInstance; // ���̃C���X�^���X
    private ArrowScaler arrowScaler;
    private Vector3 initialPosition;
    private bool isDragging = false;
    private bool isShooting = false;  // ���˒����ǂ�����ǐ�

    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // Z���W���Œ�

                // ���̃C���X�^���X�𐶐�
                arrowInstance = Instantiate(arrowPrefab, mousePosition, Quaternion.identity);
                arrowScaler = arrowInstance.GetComponent<ArrowScaler>();

                isDragging = true;
                initialPosition = mousePosition;
                arrowInstance.SetActive(true); // ����\��
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

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                isDragging = false;
                arrowInstance.SetActive(false); // �����\��
            }
 
      // �e�X�g�p�F�X�y�[�X�L�[�����Œ�~
        if (Input.GetKeyDown(KeyCode.Space))
        {
  
            isShooting = false;  // ���˒�~
            arrowScaler.StopShooting();
            Debug.Log("Space key pressed: Velocity set to 0");
        }
    }
}