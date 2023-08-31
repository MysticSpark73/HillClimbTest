using HillClimb.Core;
using HillClimb.Level;
using UnityEngine;

namespace HillClimb.Character
{
    public class VehicleDeathHandler : MonoBehaviour, IInitable
    {
        private HingeJoint2D _neckJoint;

        public void Init(HingeJoint2D hingeJoint)
        {
            _neckJoint = hingeJoint;
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag(Parameters.GroundTag))
            {
                LevelEventsManager.LevelFailed?.Invoke();
                if (_neckJoint == null) return;
                _neckJoint.useLimits = false;
            }
        }
    }
}