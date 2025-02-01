using UnityEngine;
using Zenject;

namespace Level.Gradient
{
    public abstract class GradientState
    {
        public Color TopColor { get; private set; }
        public Color MiddleColor { get; private set; }
        public Color BottomColor { get; private set; }
        
        public float MinPos { get; private set; }
        public float MaxPos { get; private set; }

        public GradientState(GradientData data, float maxPos, float minPos)
        {
            MinPos = minPos;
            MaxPos = maxPos;
            
            TopColor = data.TopColor;
            MiddleColor = data.MiddleColor;
            BottomColor = data.BottomColor;
        }

        [Inject] protected GradientBackground Context;

        public abstract void CheckStateByDistance(float pos, SpriteRenderer gradient);

        protected bool CheckPrevStateIsLower(float pos, GradientState prevState)
        {
            return pos <= prevState.MinPos;
        }
        
        protected bool CheckNextStateIsHighest(float pos, GradientState nextState)
        {
            return pos > nextState.MaxPos;
        }

        protected void SetNextState(GradientState state, SpriteRenderer gradient)
        {
            gradient.material.SetColor("TopColor", state.TopColor);
            gradient.material.SetColor("MiddleColor", state.MiddleColor);
            gradient.material.SetColor("BottomColor", state.BottomColor);
            
            Context.TransitionToState(state);
        }
    }
}