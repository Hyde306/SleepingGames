using UnityEngine;

public class TrashGameManager : MonoBehaviour
{
    public GameObject trashObject; // ゴミオブジェクト
    public float resetTime = 5.0f;  // ゴミが止まってからリセットするまでの時間
    public Vector3 initialPosition; // ゴミの初期位置

    private Rigidbody trashRigidbody;
    private bool isTrashStopped = false;
    private float timer = 0f;

    void Start()
    {
        trashRigidbody = trashObject.GetComponent<Rigidbody>();
        initialPosition = trashObject.transform.position; // 初期位置を保存
    }

    void Update()
    {
        // ゴミが動いていないかどうかをチェック
        if (trashRigidbody.IsSleeping() && !isTrashStopped)
        {
            isTrashStopped = true;
            timer = resetTime;
        }

        if (isTrashStopped)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ResetTrashPosition();
            }
        }
    }

    void ResetTrashPosition()
    {
        trashObject.transform.position = initialPosition; // 初期位置に戻す
        trashRigidbody.velocity = Vector3.zero; // 速度をリセット
        trashRigidbody.angularVelocity = Vector3.zero; // 回転速度をリセット
        isTrashStopped = false; // リセットフラグを解除
    }
}
