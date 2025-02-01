using System.Linq;
using Character;
using UnityEngine;
using Zenject;

namespace Level.Gradient
{
    public class GradientBackground : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] backgrounds;

        [Space] [SerializeField] private float backHeight = 25f;

        [Inject] private GroundGradientState _groundGradientState;
        [Inject] private ICharacterTransform _characterTransform;
        
        private int _currentPlatformIndex;
        
        private GradientState _currentState;

        private Transform _target;

        private void Awake()
        {
            _currentState = _groundGradientState;
            _target = _characterTransform.Get();
            
            InstantiateMaterials();
        }
        
        private void InstantiateMaterials()
        {
            foreach (var background in backgrounds)
            {
                var material = new Material(background.material);

                background.material = material;
            }
        }

        public void TransitionToState(GradientState state)
        {
            _currentState = state;
        }
        
        private void Update()
        {
            if (_target.position.y > GetHighestPlatform().transform.position.y - backHeight / 2)
            {
                MovePlatformUp();
            }
            
            if (_target.position.y < GetLowestPlatform().transform.position.y + backHeight / 2)
            {
                MovePlatformDown();
            }
        }

        private SpriteRenderer GetHighestPlatform()
        {
            return backgrounds.OrderByDescending(b => b.transform.position.y).First();
        }

        private SpriteRenderer GetLowestPlatform()
        {
            return backgrounds.OrderBy(b => b.transform.position.y).First();
        }

        private void MovePlatformUp()
        {
            var lowestPlatform = GetLowestPlatform();
            var highestPlatform = GetHighestPlatform();
            
            lowestPlatform.transform.position = new Vector3(lowestPlatform.transform.position.x, 
                highestPlatform.transform.position.y + backHeight, lowestPlatform.transform.position.z);

            _currentState.CheckStateByDistance(lowestPlatform.transform.position.y, lowestPlatform);
        }

        private void MovePlatformDown()
        {
            var highestPlatform = GetHighestPlatform();
            var lowestPlatform = GetLowestPlatform();
            
            highestPlatform.transform.position = new Vector3(highestPlatform.transform.position.x,
                lowestPlatform.transform.position.y - backHeight, highestPlatform.transform.position.z);
            
            _currentState.CheckStateByDistance(highestPlatform.transform.position.y, highestPlatform);
        }
    }
}