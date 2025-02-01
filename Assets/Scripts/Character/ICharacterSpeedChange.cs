using System;

namespace Character
{
    public interface ICharacterSpeedChange
    {
        public event Action<float> OnSpeedChanged; 
    }
}
