using HillClimb.Character;
using UnityEngine;

namespace HillClimb.Level
{
    public class SpawnPoint : MonoBehaviour
    {
        public GameObject Player => _playerObject;
        
        private CharacterData _characterData;
        private GameObject _playerObject;
        private VehicleView _vehicleView;
        private Transform _parentObject;
        public void SetPlayer(CharacterData characterData, Transform parentObject)
        {
            _characterData = characterData;
            _parentObject = parentObject;
        }

        public void SpawnPlayer()
        {
            if (_playerObject != null && _vehicleView != null)
            {
                _vehicleView.ResetVehicleTo(transform.position, Quaternion.identity);
                return;
            }
            _playerObject = Instantiate(_characterData.prefab, transform.position, Quaternion.identity, _parentObject);
            _vehicleView = _playerObject.GetComponent<VehicleView>();
            _vehicleView.Init(_characterData);
        }
    }
}
