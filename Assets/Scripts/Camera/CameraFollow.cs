using UnityEngine;

namespace HillClimb.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _transformSelf;
        [SerializeField] private Vector3 _offset;
        [SerializeField] [Range(0.01f, 1)] private float _followSpeed;
        
        private Transform _transformTarget;
        private bool _isFollowing;

        public void SetTarget(Transform transform) => _transformTarget = transform;

        public void SetFollow(bool value) => _isFollowing = value;
        
        private void LateUpdate()
        {
            Vector3 currentVelocity = Vector3.zero;
            Vector3 targetPosition = new Vector3(_transformTarget.position.x, _transformTarget.position.y,
                _transformSelf.position.z);
            if (!_isFollowing || _transformTarget == null) return;
            _transformSelf.position = Vector3.SmoothDamp(_transformSelf.transform.position,
                targetPosition + _offset,
                ref currentVelocity, _followSpeed);

        }
    }
}
