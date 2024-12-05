using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Interfaces : MonoBehaviour
    {
        public interface IObservable
        {
            void RegisterObserver(ITimeOfDayObserver observer);
            void RemoveObserver(ITimeOfDayObserver observer);
            void Notify();
        }

        public interface ITimeOfDayObserver
        {
            void OnTimeOfDayChanged(float time);
        }
    }
}
