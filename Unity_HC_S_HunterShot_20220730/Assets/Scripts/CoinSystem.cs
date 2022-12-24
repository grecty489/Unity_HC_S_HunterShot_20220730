using TMPro;
using UnityEngine;

namespace grecty489
{
    /// <summary>
    /// 金幣系統：接收金幣數量
    /// </summary>
    public class CoinSystem : MonoBehaviour
    {
        private int coinTotal;
        private TextMeshProUGUI textCoin;

        private void Awake()
        {
            textCoin = GameObject.Find("金幣數量").GetComponent<TextMeshProUGUI>();
        }

        /// <summary>
        /// 更新金幣
        /// </summary>
        public void UpdataCoin()
        {
            coinTotal++;
            textCoin.text = coinTotal.ToString();
        }
    }
}


