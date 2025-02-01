using UnityEngine;

namespace Character
{
    public class CharacterGroundChecker : MonoBehaviour, IGetIsGrounded
    {
        public bool GetIsGrounded() => transform.position.y <= 0;
    }
}
