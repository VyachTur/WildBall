using System.Collections;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class HintsForPlayer : MonoBehaviour
    {
        [SerializeField] private string HintString;
        [SerializeField] private TMP_Text HintText;

        private Color _hintsTextColor;

        public virtual void Start()
        {
            _hintsTextColor = HintText.color;
            ResetHint();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out _))
            {
                StopAllCoroutines();
                ResetHint();
                HintText.enabled = true;
                StartCoroutine(PrintText());
            }
        }

        private IEnumerator PrintText()
        {
            for (int i = 0; i < HintString.Length; i++)
            {
                HintText.text += HintString[i];

                yield return new WaitForSeconds(Random.Range(0.04f, 0.11f));
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Player>(out _))
            {
                StartCoroutine(TextAlphaDecrease());
            }
        }

        private IEnumerator TextAlphaDecrease()
        {
            for (float f = 1f; f >= 0f; f -= Time.deltaTime)
            {
                Color color = HintText.color;
                color.a = f;
                HintText.color = color;

                yield return new WaitForSeconds(0.005f);
            }

            ResetHint();
        }

        private void ResetHint()
        {
            HintText.text = string.Empty;
            HintText.enabled = false;
            HintText.color = _hintsTextColor;
        }
    }
}

