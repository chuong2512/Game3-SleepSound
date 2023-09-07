using BabySound.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace BabySound
{
    public class AppScreen : BaseScreen
    {
        [SerializeField] private Button _closeBtn;

        protected virtual void Start()
        {
            _closeBtn?.onClick.AddListener(Back);
        }
    }
}