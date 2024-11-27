using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject garbageObject; // ゴミオブジェクト
    public GameObject fireEffectPrefab; // 火のエフェクトのプレハブ

    private void Start()
    {
        // ゴミオブジェクトは最初に表示される
        garbageObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // スペースキーが押されたときの動作
            StartCoroutine(ShowFireEffect());
        }
    }

    private System.Collections.IEnumerator ShowFireEffect()
    {
        // ゴミオブジェクトの位置を取得
        Vector3 position = garbageObject.transform.position;

        // ゴミオブジェクトを非表示にする
        garbageObject.SetActive(false);

        // 火のエフェクトをゴミオブジェクトの位置に生成
        GameObject fireEffect = Instantiate(fireEffectPrefab, position, Quaternion.identity);

        // 1秒待機
        yield return new WaitForSeconds(1.0f);

        // 火のエフェクトを非表示にする（オプション）
        fireEffect.SetActive(false);
    }
}
