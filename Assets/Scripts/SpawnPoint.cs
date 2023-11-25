using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Target _target;
    
    private Renderer _renderer;
    
    public Color GetCurrentColor => _renderer.material.color;

    public Target GetTarget => _target;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
}
