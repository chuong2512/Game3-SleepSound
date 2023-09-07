using System;
using DG.Tweening;
using UnityEngine;

namespace BabySound.Scripts.UI
{
    public class SetTimePopup : BasePopup
    {
        [SerializeField] private SetTimeButton[] _setTimeButtons;

        public override void OnOpen()
        {
            base.OnOpen();
            transform.DOKill();
            transform.localScale = Vector3.one * 0.5f;
            transform.DOScale(Vector3.one, 0.2f);
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            _setTimeButtons = GetComponentsInChildren<SetTimeButton>();
        }

        private void Start()
        {
            for (int i = 0; i < _setTimeButtons.Length; i++)
            {
                _setTimeButtons[i].SetTime(i);
            }
        }
    }
}