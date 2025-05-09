using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletTextureSetter : MonoBehaviour
{
    [SerializeField] Texture texture;

    void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.material.mainTexture = texture;
    }
}
