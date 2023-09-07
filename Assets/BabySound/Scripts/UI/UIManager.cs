using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BabySound.Scripts;
using SingleApp;
using Sirenix.OdinInspector;
using UnityEngine;

public enum ScreenType
{
    Back = -1,
    HomeScreen = 0,
    IAPScreen,
    RegisterScreen,
    ChooseSongScreen,
    SongScreen,
    SetTimePopup,
    UnlockPopup,
}

public class UIManager : PersistentSingleton<UIManager>
{
    [SerializeField] private BasePopup[] _screens;

    private List<BasePopup> _listScreens = new List<BasePopup>();
    private BasePopup _currentScreen;

    [SerializeField] private Transform _openingPopups, _closingPopups;
    [SerializeField] private Transform _overlay;

    public Transform OpeningPopups => _openingPopups;
    public Transform ClosingPopups => _closingPopups;
    public BasePopup CurrentScreen => _currentScreen;

    void Start()
    {
        OpenScreen(ScreenType.HomeScreen);
    }

    [Button]
    public void OpenScreen(ScreenType screenType)
    {
        if (_currentScreen != null)
        {
            if (_currentScreen is BaseScreen)
            {
                _currentScreen.Hide();
            }
            else
            {
                _currentScreen.CloseView();
            }
        }

        BasePopup screen = _listScreens.Find(s => s.ID == screenType);

        if (screen == null)
        {
            screen = Instantiate(_screens.ToList().Find(popup => popup.ID == screenType), transform);
            _listScreens.Add(screen);
        }

        _overlay.gameObject.SetActive(screen is not BaseScreen);

        _overlay.SetAsLastSibling();
        screen.Add();
        _currentScreen = screen;
    }


    [Button]
    public void Back()
    {
        _overlay.SetAsFirstSibling();
        _overlay.gameObject.SetActive(false);

        int childCount = _openingPopups.childCount;

        if (childCount >= 2 && _currentScreen != null)
        {
            _currentScreen.Remove();
            _currentScreen = _openingPopups.GetChild(childCount - 2).GetComponent<BasePopup>();
            _currentScreen.Show();
        }
    }
}