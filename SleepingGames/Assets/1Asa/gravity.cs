using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    public float objectMass = 1.0f; // オブジェクトの質量を設定
    public float bounciness = 0.5f; // 反発係数を設定

    void Start()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = true;
        rb.mass = objectMass;

        // 反発係数を設定するためのPhysicsMaterialを作成
        PhysicMaterial bounceMaterial = new PhysicMaterial();
        bounceMaterial.bounciness = bounciness;
        bounceMaterial.bounceCombine = PhysicMaterialCombine.Maximum;

        Collider collider = gameObject.GetComponent<Collider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider>(); // デフォルトでBoxColliderを追加
        }
        collider.material = bounceMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
