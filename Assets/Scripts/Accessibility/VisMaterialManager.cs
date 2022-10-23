using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisMaterialManager : MonoBehaviour
{
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material lowVisMaterial;
    [SerializeField] private Outline outline;

    private Material material;
    private MeshRenderer m_renderer;

    private void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // sets the material
        if (normalMaterial != null && lowVisMaterial != null)
            material = AccessibilityManager.Instance.HighContrastMode ? lowVisMaterial : normalMaterial;

        if (m_renderer != null)
            m_renderer.material = material;

        outline.enabled = !AccessibilityManager.Instance.HighContrastMode;
    }
}
