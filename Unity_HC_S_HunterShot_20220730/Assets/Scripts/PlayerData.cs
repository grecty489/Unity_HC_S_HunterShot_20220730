using UnityEngine;

namespace grecty489
{
    /// <summary>
    /// 玩家資料
    /// </summary>
    public class PlayerData : MonoBehaviour
    {
        [SerializeField, Header("玩家攻擊力基底"), Range(0, 10000)]
        private float baseAttack = 100;
        [SerializeField, Header("玩家攻擊力爆擊率"), Range(0f, 1f)]
        private float baseCritProbability = 0.5f;
        [Header("玩家血量"), Range(0f, 5000f)]
        public float hp = 1500;

        // 屬性 Property
        // 與欄位很相似，儲存資料，可以設定存取權限
        // 完成方式：prop + Tab *2
        // 如果本次機率是爆擊率 就將攻擊力 乘以二
        // 取得隨機.值 0～1 小於 爆擊率
        public float attack
        {
            get
            {
                // 如果隨機.值 小於 爆擊率 就回傳 攻擊 * 2
                // 否則 傳回 攻擊
                if (Random.value < baseCritProbability) return baseAttack * 2;
                else return baseAttack;
            }
        }

        private void Awake()
        {
            print($"<color=#1166ff>攻擊力：{attack}</color>");
        }
    }
}