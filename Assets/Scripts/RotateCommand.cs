using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCommand : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Note: Interaction window is determined by the size of the collider of the object this is attached to.
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationDamping;

    private float _rotationVelocity;
    private bool _dragged;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rotationVelocity = eventData.delta.x * rotationSpeed;
        transform.Rotate(Vector3.up, -_rotationVelocity, Space.Self);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragged = false;
    }

    private void Update()
    {
        if (!_dragged && !Mathf.Approximately(_rotationVelocity, 0))
        {
            // decide whether the model is being dragged or using momentum to rotate (increase damping for no momentum)
            float deltaVelocity = Mathf.Min(
                Mathf.Sign(_rotationVelocity) * Time.deltaTime * rotationDamping,
                Mathf.Sign(_rotationVelocity) * _rotationVelocity
            );

            // apply rotation
            _rotationVelocity -= deltaVelocity;
            transform.Rotate(Vector3.up, -_rotationVelocity, Space.Self);
        }
    }
}
