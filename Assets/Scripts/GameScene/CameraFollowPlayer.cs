using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed;
    void LateUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothPos;
    }
}
