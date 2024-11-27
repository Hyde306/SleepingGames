using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject garbageObject; // �S�~�I�u�W�F�N�g
    public GameObject fireEffectPrefab; // �΂̃G�t�F�N�g�̃v���n�u

    private void Start()
    {
        // �S�~�I�u�W�F�N�g�͍ŏ��ɕ\�������
        garbageObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �X�y�[�X�L�[�������ꂽ�Ƃ��̓���
            StartCoroutine(ShowFireEffect());
        }
    }

    private System.Collections.IEnumerator ShowFireEffect()
    {
        // �S�~�I�u�W�F�N�g�̈ʒu���擾
        Vector3 position = garbageObject.transform.position;

        // �S�~�I�u�W�F�N�g���\���ɂ���
        garbageObject.SetActive(false);

        // �΂̃G�t�F�N�g���S�~�I�u�W�F�N�g�̈ʒu�ɐ���
        GameObject fireEffect = Instantiate(fireEffectPrefab, position, Quaternion.identity);

        // 1�b�ҋ@
        yield return new WaitForSeconds(1.0f);

        // �΂̃G�t�F�N�g���\���ɂ���i�I�v�V�����j
        fireEffect.SetActive(false);
    }
}
