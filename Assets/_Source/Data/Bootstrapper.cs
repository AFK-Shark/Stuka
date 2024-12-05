using DayNight;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        public DayNightCycle dayNightCycle;
        public Sun sun;
        public Sky sky;
        public Stars stars;

        void Start()
        {
            // Убедитесь, что все ссылки установлены
            if (dayNightCycle != null)
            {
                sun.dayNightCycle = dayNightCycle;
                sky.dayNightCycle = dayNightCycle;
                stars.dayNightCycle = dayNightCycle;
            }
        }
    }
}
