using UnityEngine;
using Cinemachine;

public class Shaker : MonoBehaviour
{
    public GameObject explosion; // 爆発プレハブをセット
    private string answerTag = "tukue";

    public void onClickAct()
    {
        if (this.gameObject.CompareTag(answerTag)) // Tagと変数が同じだったら
        {
            Instantiate(explosion, transform.position, Quaternion.identity); // 爆発
        }

    }
}
