﻿using BabySound.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BabySound
{
    public class RegisterScreen : AppScreen
    {
        [SerializeField] private BuyTimeButton[] _buttons;

        protected override void Start()
        {
            base.Start();

            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Index = i;
            }
        }

        public override void Back()
        {
            if (GameDataManager.Instance.playerData.time > 0)
            {
                base.Back();
            }
        }
    }
}