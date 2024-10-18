using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    public float objectMass = 1.0f; // �I�u�W�F�N�g�̎��ʂ�ݒ�
    public float bounciness = 0.5f; // �����W����ݒ�

    void Start()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = true;
        rb.mass = objectMass;

        // �����W����ݒ肷�邽�߂�PhysicsMaterial���쐬
        PhysicMaterial bounceMaterial = new PhysicMaterial();
        bounceMaterial.bounciness = bounciness;
        bounceMaterial.bounceCombine = PhysicMaterialCombine.Maximum;

        Collider collider = gameObject.GetComponent<Collider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider>(); // �f�t�H���g��BoxCollider��ǉ�
        }
        collider.material = bounceMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
