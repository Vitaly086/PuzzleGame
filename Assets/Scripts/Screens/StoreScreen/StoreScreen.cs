using Events;
using Score;
using ScreenManager.Core;
using UnityEngine;

namespace Screens.StoreScreen
{
    public class StoreScreen :  UIScreen<StoreScreenContext>
    {
        [SerializeField] private ScoreView _scoreView;
        
        public override void Initialize(StoreScreenContext context)
        {
            EventStreams.UserInterface.Publish(new OpenStoreEvent());
            _scoreView.UpdateView(context.Score);
        }
    }
}