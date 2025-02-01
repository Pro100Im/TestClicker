using System;
using CustomInput;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterMovement : MonoBehaviour, ICharacterSpeedChange, ICharacterTransform
    {
        public event Action<float> OnSpeedChanged;

        [SerializeField] private float speedIncrement = 0.25f;
        [SerializeField] private float speedDecay = 1f;
        [SerializeField] private float minSpeed = -1f;
        [SerializeField] private float maxSpeed = 10f;
        [SerializeField] private float decayDelay = 1f;

        [Inject] private IGetIsGrounded groundChecker;
        [Inject] private IClickDetect clickDetect;

        private float _speed;
        private float _lastClickTime;

        private void Start()
        {
            clickDetect.OnClick += SpeedUp;
        }

        public Transform Get() => transform;

        private void SpeedUp()
        {
            if (_speed < maxSpeed)
            {
                _speed += speedIncrement;
                OnSpeedChanged?.Invoke(_speed);
            }

            _lastClickTime = Time.time;
        }

        private void FixedUpdate()
        {
            Flying();
        }

        private void Flying()
        {
            var isGrounded = groundChecker.GetIsGrounded();
            
            if (isGrounded && _speed <= 0)
            {
                _speed = 0;
                OnSpeedChanged?.Invoke(_speed);
            }
            else
            {
                SpeedDown();
                
                transform.position += Vector3.up * _speed * Time.fixedDeltaTime;
            }
        }

        private void SpeedDown()
        {
            if (_speed <= minSpeed)
                return;
            
            if (Time.time - _lastClickTime > decayDelay)
            {
                _speed -= speedDecay;
                _lastClickTime = Time.time;

                OnSpeedChanged?.Invoke(_speed);
            }
        }

        private void OnDestroy()
        {
            clickDetect.OnClick -= SpeedUp;
        }
    }
}