using UnityEngine;

public class hanabi : MonoBehaviour
{
    public ParticleSystem firework;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gomibako"))
        {
            Debug.Log("ゴミが接触しました！");
            if (firework != null)
            {
                firework.Stop();  // まずパーティクルシステムを停止します
                firework.Play();  // その後再度再生します
            }
        }
    }
}
