using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraComponent : MonoBehaviour
{
    [Header("Global Parameters")]
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private float followSmoothness;
    
    private void FixedUpdate() {
        SetCameraPosition();
    }

    private void SetCameraPosition() {
        transform.position = Vector3.Lerp(transform.position, target.position + offsetPosition,
            Time.fixedDeltaTime * followSmoothness);
        transform.LookAt(target);
    }

#if UNITY_EDITOR

    [Conditional("DEBUG")]
    private void EditorSetCameraPosition() {
        transform.position = target.position + offsetPosition;
        transform.LookAt(target);
    }
    
    [Conditional("DEBUG")]
    private void OnValidate() {
        EditorSetCameraPosition();
    }
    
#endif
    
}
