using TMPro;
using UnityEngine;

namespace grecty489
{
    /// <summary>
    /// �����t�ΡG���������ƶq
    /// </summary>
    public class CoinSystem : MonoBehaviour
    {
        private int coinTotal;
        private TextMeshProUGUI textCoin;

        private void Awake()
        {
            textCoin = GameObject.Find("�����ƶq").GetComponent<TextMeshProUGUI>();
        }

        /// <summary>
        /// ��s����
        /// </summary>
        public void UpdataCoin()
        {
            coinTotal++;
            textCoin.text = coinTotal.ToString();
        }
    }
}


