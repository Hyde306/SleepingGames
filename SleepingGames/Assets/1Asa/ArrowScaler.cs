using UnityEngine;

public class ArrowScaler : MonoBehaviour
{
    public float maxLength = 3.0f; // Å‘å’·‚³
    public float minLength = 0.5f; // Å¬’·‚³

    public void SetLength(float length)
    {
        Vector3 scale = transform.localScale;
        scale.y = Mathf.Clamp(length, minLength, maxLength);
        transform.localScale = scale;
    }

    public void SetRotation(Vector3 direction)
    {
        transform.up = direction; // –îˆó‚ÌŒü‚«‚ğİ’è
    }
}
