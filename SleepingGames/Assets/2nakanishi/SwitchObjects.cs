using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchObjects : MonoBehaviour
{
    public GameObject initialObject; // 最初に表示されるオブジェクト
    public List<GameObject> objects; // 出現させるオブジェクトのリスト
    public float delay = 2f; // 各オブジェクトを出現させるまでの遅延時間（秒）
    private int currentIndex = 0; // 現在のオブジェクトのインデックス
    private bool isSwitching = false; // コルーチンが実行中かどうかのフラグ

    void Start()
    {
        // 全てのオブジェクトを初期状態で非表示にする
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        if (initialObject != null)
        {
            initialObject.SetActive(true); // ゲーム開始時に最初のオブジェクトを表示する
            Debug.Log("初期オブジェクトが表示されました。");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSwitching)
        {
            Debug.Log("スペースキーが押されました。"); // デバッグメッセージ
            StartCoroutine(SwitchObjectsSequentially());
        }
    }

    private IEnumerator SwitchObjectsSequentially()
    {
        isSwitching = true; // コルーチンが実行中であることを示す

        // 初期オブジェクトが正しく設定されているか確認
        if (initialObject != null)
        {
            // 初期オブジェクトの位置を取得
            Vector3 initialPosition = initialObject.transform.position;
            Debug.Log($"初期オブジェクトの位置: {initialPosition}"); // デバッグメッセージ

            // 初期オブジェクトを非表示にする
            initialObject.SetActive(false);
            Debug.Log("初期オブジェクトが非表示になりました。");

            // 遅延してオブジェクトを表示する
            while (currentIndex < objects.Count)
            {
                GameObject currentObject = objects[currentIndex];

                // 現在のオブジェクトが null でないことを確認
                if (currentObject != null)
                {
                    // 次のオブジェクトを初期オブジェクトの位置に移動させる
                    currentObject.transform.position = initialPosition;
                    Debug.Log($"次のオブジェクト {currentObject.name} の位置を {initialPosition} に設定しました。"); // デバッグメッセージ

                    yield return new WaitForSeconds(delay);

                    currentObject.SetActive(true);
                    Debug.Log($"{currentObject.name} が初期オブジェクトの位置に表示されました。位置: {initialPosition}"); // デバッグメッセージ
                }

                // 次のオブジェクトに進む
                currentIndex++;
            }
        }

        isSwitching = false; // コルーチンが終了したことを示す
    }
}
