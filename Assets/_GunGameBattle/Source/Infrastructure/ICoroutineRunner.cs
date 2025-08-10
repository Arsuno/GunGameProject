using System.Collections;
using UnityEngine;

namespace _GunGameBattle.Source.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}