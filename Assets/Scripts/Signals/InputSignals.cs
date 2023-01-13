using UnityEngine;
using UnityEngine.Events;
using Keys;

namespace Assets.Scripts.Signals
{
    public class InputSignals : MonoBehaviour
    {
        public UnityAction onFirstTimeTouchTaken = delegate { };
        public UnityAction onInputReleased = delegate { };
        public UnityAction onInputTaken = delegate { };
        public UnityAction<HorizontalInputParams> onInputDragged = delegate { };
    }
}