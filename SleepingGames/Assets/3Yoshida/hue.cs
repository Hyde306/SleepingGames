using UnityEngine;

public class hue : MonoBehaviour
{
    public GameObject objectToDuplicate;
    public float duplicationInterval = 1f;
    public int maxDuplicates = 100;
    private int currentDuplicateCount = 0;

    void Start()
    {
        InvokeRepeating("DuplicateObject", duplicationInterval, duplicationInterval);
    }

    void DuplicateObject()
    {
        if (currentDuplicateCount < maxDuplicates)
        {
            Instantiate(objectToDuplicate, transform.position, transform.rotation);
            currentDuplicateCount++;
        }
        else
        {
            CancelInvoke("DuplicateObject");
        }
    }
}