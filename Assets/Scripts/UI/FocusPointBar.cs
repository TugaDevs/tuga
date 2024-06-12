using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ds
{
    public class FocusPointBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxFocusPoint(float maxFocusPoints)
        {
            slider.maxValue = maxFocusPoints;
            slider.value = maxFocusPoints;
        }

        public void SetCurrentFocusPoint(float currentFocusPoints)
        {
            slider.value = currentFocusPoints;
        }
    }
}
