using CustomInput;
using Rewards;
using UnityEngine;
using Zenject;

namespace Effects
{
    public class ClickEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle;
        
        [Inject] ICoinGain coinGain;
        [Inject] IGetInputLastPoint getInputLastPoint;
        
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            
            coinGain.OnCoinGained += PlayEffect;
        }
        
        private void PlayEffect(int value)
        {
            var point = getInputLastPoint.GetPoint();
            Vector3 worldPosition = _camera.ScreenToWorldPoint(new Vector3(point.x, point.y, _camera.nearClipPlane));
            
            particle.transform.position = worldPosition;
            
            particle.Play();
        }
        
        private void OnDestroy()
        {
            coinGain.OnCoinGained -= PlayEffect;
        }
    }
}
