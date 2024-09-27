using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Clock
{
    public class DigitalClockView : MonoBehaviour
    {
        [SerializeField] private Text _timeText;

        private ClockViewModel _clockViewModel;

        public void Init(ClockViewModel viewModel)
        {
            _clockViewModel = viewModel;

            _clockViewModel.Date.OnChangeEvent += OnChangeTime;
        }

        private void OnChangeTime(DateTimeOffset date)
        {
            _timeText.text = string.Format("{0 : 00}:{1 : 00}:{2 : 00}", 
                date.Hour, date.Minute, date.Second);
        }

        private void OnDestroy()
        {
            _clockViewModel.Date.OnChangeEvent -= OnChangeTime;
        }
    }
}