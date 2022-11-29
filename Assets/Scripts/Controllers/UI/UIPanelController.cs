using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Signals;
using System.Linq;

namespace Controller.UI
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<Transform> layers = new List<Transform>();

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }
        private void SubscribeEvents()
        {
            CoreUISignals.Instance.onOpenPanel += OnOpenPanel;
            CoreUISignals.Instance.onClosePanel += OnClosePanel;
            CoreUISignals.Instance.onCloseAllPanels += OnCloseAllPanels;
        }
        private void UnsubsribeEvents()
        {
            CoreUISignals.Instance.onOpenPanel -= OnOpenPanel;
            CoreUISignals.Instance.onClosePanel -= OnClosePanel;
            CoreUISignals.Instance.onCloseAllPanels -= OnCloseAllPanels;
        }
        private void OnDisable()
        {
            UnsubsribeEvents();
        }

        //[Button("OnOpenPanel")]
        private void OnOpenPanel(UIPanelTypes type, int layerValue)
        {
            OnClosePanel(layerValue);
            Instantiate(Resources.Load<GameObject>($"Screens/{type}Panel"), layers[layerValue]);
        }

        //[Button("OnClosePanel")]
        private void OnClosePanel(int layerValue)
        {
            if (layers[layerValue].childCount > 0)
            {
                Destroy(layers[layerValue].GetChild(0).gameObject);
            }
        }

        [Button("OnCloseAllPanels")]
        private void OnCloseAllPanels()
        {
            foreach (var t in layers.Where(t => t.childCount > 0))
            {
                Destroy(t.GetChild(0).gameObject);
            }
        }
    }

}
