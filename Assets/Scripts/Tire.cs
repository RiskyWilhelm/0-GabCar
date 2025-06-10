using UnityEngine;

public class Tire : MonoBehaviour
{
    [field: SerializeField] public Transform Visual {get; private set; }
    [field: SerializeField] public WheelCollider WheelCollider {get; private set; } 
    [field: SerializeField] public bool IsSteerer { get; private set; }
    [field: SerializeField] public bool IsAccelerater { get; private set; }
    [field: SerializeField] public bool IsBraker { get; private set; }

    // Correctly applies the transform
    public void ApplyLocalPositionToVisuals()
    {
        if (Visual == null)
            return;

        WheelCollider.GetWorldPose(out Vector3 position, out Quaternion rotation);
        Visual.transform.SetPositionAndRotation(position, rotation);
    }
}
