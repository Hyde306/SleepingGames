using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchObjects : MonoBehaviour
{
    public GameObject initialObject; // �ŏ��ɕ\�������I�u�W�F�N�g
    public List<GameObject> objects; // �o��������I�u�W�F�N�g�̃��X�g
    public float delay = 2f; // �e�I�u�W�F�N�g���o��������܂ł̒x�����ԁi�b�j
    private int currentIndex = 0; // ���݂̃I�u�W�F�N�g�̃C���f�b�N�X
    private bool isSwitching = false; // �R���[�`�������s�����ǂ����̃t���O

    void Start()
    {
        // �S�ẴI�u�W�F�N�g��������ԂŔ�\���ɂ���
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        if (initialObject != null)
        {
            initialObject.SetActive(true); // �Q�[���J�n���ɍŏ��̃I�u�W�F�N�g��\������
            Debug.Log("�����I�u�W�F�N�g���\������܂����B");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSwitching)
        {
            Debug.Log("�X�y�[�X�L�[��������܂����B"); // �f�o�b�O���b�Z�[�W
            StartCoroutine(SwitchObjectsSequentially());
        }
    }

    private IEnumerator SwitchObjectsSequentially()
    {
        isSwitching = true; // �R���[�`�������s���ł��邱�Ƃ�����

        // �����I�u�W�F�N�g���������ݒ肳��Ă��邩�m�F
        if (initialObject != null)
        {
            // �����I�u�W�F�N�g�̈ʒu���擾
            Vector3 initialPosition = initialObject.transform.position;
            Debug.Log($"�����I�u�W�F�N�g�̈ʒu: {initialPosition}"); // �f�o�b�O���b�Z�[�W

            // �����I�u�W�F�N�g���\���ɂ���
            initialObject.SetActive(false);
            Debug.Log("�����I�u�W�F�N�g����\���ɂȂ�܂����B");

            // �x�����ăI�u�W�F�N�g��\������
            while (currentIndex < objects.Count)
            {
                GameObject currentObject = objects[currentIndex];

                // ���݂̃I�u�W�F�N�g�� null �łȂ����Ƃ��m�F
                if (currentObject != null)
                {
                    // ���̃I�u�W�F�N�g�������I�u�W�F�N�g�̈ʒu�Ɉړ�������
                    currentObject.transform.position = initialPosition;
                    Debug.Log($"���̃I�u�W�F�N�g {currentObject.name} �̈ʒu�� {initialPosition} �ɐݒ肵�܂����B"); // �f�o�b�O���b�Z�[�W

                    yield return new WaitForSeconds(delay);

                    currentObject.SetActive(true);
                    Debug.Log($"{currentObject.name} �������I�u�W�F�N�g�̈ʒu�ɕ\������܂����B�ʒu: {initialPosition}"); // �f�o�b�O���b�Z�[�W
                }

                // ���̃I�u�W�F�N�g�ɐi��
                currentIndex++;
            }
        }

        isSwitching = false; // �R���[�`�����I���������Ƃ�����
    }
}
