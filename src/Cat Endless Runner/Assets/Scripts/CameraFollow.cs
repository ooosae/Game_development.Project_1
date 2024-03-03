using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _offset;
    
    private void Start() {
        _offset = transform.position - _player.position;
    }

    private void Update() {
        Vector3 targetPosition = _player.position + _offset;
        targetPosition.x = 0;
        targetPosition.y = 8;
        transform.position = targetPosition;
    }
}
