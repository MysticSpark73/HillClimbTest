using HillClimb.Core;
using HillClimb.Input;
using UnityEngine;

namespace HillClimb.Character
{
    public class VehicleController : IInitable
    {
        private Rigidbody2D _wheelFront, _wheelBack, _rigidbodySelf;
        private float _defaultAcceleration, _defaultTorque;

        public VehicleController(Rigidbody2D wheelFront, Rigidbody2D wheelBack, Rigidbody2D rigidbodySelf,
            float defaultAcceleration, float defaultTorque )
        {
            _wheelFront = wheelFront;
            _wheelBack = wheelBack;
            _rigidbodySelf = rigidbodySelf;
            _defaultAcceleration = defaultAcceleration;
            _defaultTorque = defaultTorque;
            Init();
        }

        public void Init()
        {
            InputEventsManager.GasPedalPressed += OnGasPressed;
            InputEventsManager.BreakPedalPressed += OnBreakPressed;
        }

        private void OnGasPressed(bool value)
        {
            _wheelFront.AddTorque(-_defaultAcceleration * Time.deltaTime);
            _wheelBack.AddTorque(-_defaultAcceleration * Time.deltaTime);
            _rigidbodySelf.AddTorque(_defaultTorque * Time.deltaTime);
        }

        private void OnBreakPressed(bool value)
        {
            _wheelFront.AddTorque(_defaultAcceleration * Time.deltaTime);
            _wheelBack.AddTorque(_defaultAcceleration * Time.deltaTime);
            _rigidbodySelf.AddTorque(-_defaultTorque * Time.deltaTime);
        }
    }
}