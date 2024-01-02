using Events;
using JetBrains.Annotations;
using ScreenManager.Core;
using SimpleEventBus.Disposables;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.MetaGameScreen
{
    public class MetaGameScreen : UIScreen<MetaGameContext>
    {
        [SerializeField]
        private Sprite _normalButtonSprite;
        [SerializeField]
        private Sprite _selectedButtonSprite;
        [SerializeField]
        private Button _menuButton;
        [SerializeField]
        private Button _storeButton;
        [SerializeField]
        private Button _leaderboardButton;

        private CompositeDisposable _subscriptions;

        public override void Initialize(MetaGameContext context)
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<OpenMenuEvent>(OpenMenuEventHandler),
                EventStreams.UserInterface.Subscribe<OpenStoreEvent>(OpenShopEventHandler),
                EventStreams.UserInterface.Subscribe<OpenLeaderboardEvent>(OpenLeaderboardsEventHandler)
            };

            EventStreams.UserInterface.Publish(new OpenMetaGameScreenEvent());
        }

        [UsedImplicitly]
        public void PressStoreButton()
        {
            EventStreams.UserInterface.Publish(new StoreButtonPressedEvent());
        }

        [UsedImplicitly]
        public void PressMenuButton()
        {
            EventStreams.UserInterface.Publish(new MenuButtonPressedEvent());
        }

        [UsedImplicitly]
        public void PressLeaderboardButton()
        {
            EventStreams.UserInterface.Publish(new LeaderboardButtonPressedEvent());
        }

        private void OpenMenuEventHandler(OpenMenuEvent obj)
        {
            ResetButtons();
            ChangeButtonToSelected(_menuButton);
        }

        private void OpenShopEventHandler(OpenStoreEvent obj)
        {
            ResetButtons();
            ChangeButtonToSelected(_storeButton);
        }

        private void OpenLeaderboardsEventHandler(OpenLeaderboardEvent obj)
        {
            ResetButtons();
            ChangeButtonToSelected(_leaderboardButton);
        }

        private void ResetButtons()
        {
            ChangeButtonToNormal(_storeButton);
            ChangeButtonToNormal(_menuButton);
            ChangeButtonToNormal(_leaderboardButton);
        }

        private void ChangeButtonToNormal(Button button)
        {
            button.image.sprite = _normalButtonSprite;
            button.interactable = true;
        }

        private void ChangeButtonToSelected(Button button)
        {
            button.image.sprite = _selectedButtonSprite;
            button.interactable = false;
        }

        public void OnDisable()
        {
            _subscriptions?.Dispose();
        }
    }
}