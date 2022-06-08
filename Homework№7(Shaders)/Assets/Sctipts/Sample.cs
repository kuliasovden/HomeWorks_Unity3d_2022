using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private string _grayScalerParametr = "_isGrayScale";

    private bool _isGrayscaled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Switch Grayscale")]
    private void SwitchGrayScale()
    {
        _isGrayscaled = !_isGrayscaled;
        _meshRenderer.sharedMaterial.SetFloat(_grayScalerParametr, _isGrayscaled ? 1f : 0f);
    }
}
