using UnityEngine;
using Cinemachine;

public class Shaker : MonoBehaviour
{
    public GameObject explosion; // �����v���n�u���Z�b�g
    private string answerTag = "tukue";

    public void onClickAct()
    {
        if (this.gameObject.CompareTag(answerTag)) // Tag�ƕϐ���������������
        {
            Instantiate(explosion, transform.position, Quaternion.identity); // ����
        }

    }
}
