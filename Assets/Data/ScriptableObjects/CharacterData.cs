using UnityEngine;

namespace HillClimb
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/Character")]
    public class CharacterData : ScriptableObject
    {
        public GameObject prefab;
        public float defaultAcceleration, defaultTorque;
    }
}
