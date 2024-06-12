using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ds
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxHealth(int maxHealt)
        {
            slider.maxValue = maxHealt;
            slider.value = maxHealt;
        }

        public void SetCurrentHealt(int currentHealth)
        {
            slider.value = currentHealth;
        }
    }
}
