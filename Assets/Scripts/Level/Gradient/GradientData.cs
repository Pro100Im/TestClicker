using System;
using UnityEngine;

namespace Level.Gradient
{
    [Serializable]
    public class GradientData
    {
        [field: SerializeField] public Color TopColor { get; private set; }
        [field: SerializeField] public Color MiddleColor { get; private set; }
        [field: SerializeField] public Color BottomColor { get; private set; }
    }
}
