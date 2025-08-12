using System;

namespace _GunGameBattle.Source.Infrastructure.Data
{
    public interface IGameStorage
    {
        void Load(Action<bool, string> onCompleted);
        void Save(string data);
    }
}