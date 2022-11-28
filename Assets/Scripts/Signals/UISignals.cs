using Extensions;
using UnityEngine.Events;
using UnityEngine.Experimental.AI;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<int> onSetNewLevelValue = delegate { };
    }
}
