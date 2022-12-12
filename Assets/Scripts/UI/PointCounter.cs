using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    private void Start()
    {
        text.text = string.Format("{0:000}", GameManager.Instance.Score);
    }

    private void Update()
    {
        text.text = string.Format("{0:000}", GameManager.Instance.Score);
    }
}
