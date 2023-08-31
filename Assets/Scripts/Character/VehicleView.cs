using HillClimb.Core;
using UnityEngine;

namespace HillClimb.Character
{
    public class VehicleView : MonoBehaviour, IInitable
    {
        [SerializeField] private Rigidbody2D _wheelFront;
        [SerializeField] private Rigidbody2D _wheelBack;
        [SerializeField] private Rigidbody2D _rigidbodySelf;
        [SerializeField] private HingeJoint2D _neckJoint;
        [Space(10)] 
        [SerializeField] private VehicleDeathHandler _deathHandler;

        private VehicleController _vehicleController;

        public virtual void Init(CharacterData characterData)
        {
            _vehicleController = new VehicleController(_wheelFront, _wheelBack, _rigidbodySelf, 
                characterData.defaultAcceleration, characterData.defaultTorque);
            _deathHandler.Init(_neckJoint);
        }

        public void ResetVehicleTo(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
            _neckJoint.useLimits = true;
        }
    }
}