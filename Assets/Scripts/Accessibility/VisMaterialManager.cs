using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisMaterialManager : MonoBehaviour
{
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material lowVisMaterial;

    private Material material;

    private void Update()
    {
        // sets the material
        if (normalMaterial != null && lowVisMaterial != null)
        { 
            material = AccessibilityManager.Instance.HighContrastMode ? lowVisMaterial : normalMaterial;
            gameObject.GetComponent<MeshRenderer>().material = material;
        }
    }
}
