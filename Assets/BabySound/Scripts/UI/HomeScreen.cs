using System;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace BabySound
{
    public class HomeScreen : AppScreen
    {
        [SerializeField] private TextMeshProUGUI _coinTMP;

        protected override void Start()
        {
            base.Start();
            SetCoinText();
            GameManager.OnChangeCoin += OnChangeCoin;
        }

        private void OnChangeCoin(int i)
        {
            SetCoinText();
        }

        private void SetCoinText()
        {
            _coinTMP.SetText(GameDataManager.Instance.playerData.intDiamond.ToString() + "<sprite=0>");
        }

        private void OnDestroy()
        {
            GameManager.OnChangeCoin -= OnChangeCoin;
        }
    }
}