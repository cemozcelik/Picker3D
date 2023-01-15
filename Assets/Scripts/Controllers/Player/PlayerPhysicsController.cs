using Controllers.Pool;
using DG.Tweening;
using Managers;
using Signals;
using System.Collections;
using UnityEngine;
using TMPro;

namespace Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StageArea"))
            {
                manager.ForceCommand.Execute();
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                DOVirtual.DelayedCall(3, () =>
                {
                    var result = other.transform.parent.GetComponentInChildren<PoolController>()
                        .TakeStageResult(manager.StageValue);
                    if (result)
                    {
                        CoreGameSignals.Instance.onStageAreaSuccessful?.Invoke(manager.StageValue);
                        InputSignals.Instance.onEnableInput?.Invoke();
                    }
                    else CoreGameSignals.Instance.onLevelFailed?.Invoke();
                });
                return;
            }

            if (other.CompareTag("Finish"))
            {
                CoreGameSignals.Instance.onFinishAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                return;
            }


            if (other.CompareTag("MinigameArea"))
            {
                StartCoroutine(MinigameFinish());
            }
        }

        IEnumerator MinigameFinish()
        {
            float collectedCount = PlayerPrefs.GetInt("TotalCollectedCount", 0);

            yield return new WaitForSecondsRealtime(collectedCount / 10f);

            InputSignals.Instance.onDisableInput?.Invoke();
            CoreGameSignals.Instance.onFinishAreaEntered?.Invoke();

            float position = GameObject.Find("PlayerManager").transform.position.z;
            float score = Mathf.RoundToInt(position);

            CoreGameSignals.Instance.onLevelSuccessful?.Invoke();

            GameObject.Find("TXTScore").GetComponent<TextMeshProUGUI>().text = ("Score: " + score.ToString());
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            var transform1 = manager.transform;
            var position = transform1.position;
            Gizmos.DrawSphere(new Vector3(position.x, position.y - 1.2f, position.z + 1f), 1.65f);
        }

        internal void OnReset()
        {

        }
    }
}