using UnityEngine;

namespace grecty489
{
    /// <summary>
    /// 怪物資料：怪物血量、攻擊力、掉寶物件、機率
    /// </summary>
    /// Scriptable Object 腳本化物件
    /// 目的：將腳本的資料儲存在 Project 內方便管理
    /// CAM 建立素材選單
    /// menuName 選單名稱：主選單/次選單/次次選單/...
    /// fileName 檔案名稱：建議使用英文
    [CreateAssetMenu(menuName = "grecty489/Data Enemy", fileName = "New Data Enemy")]
    public class DataEnemy : ScriptableObject
    {
        [Header("基本屬性")]
        [Range(1, 5000)]
        public float hp;
        [Range(1, 5000)]
        public float attack;
        [Space(20)]
        [Header("金幣資料")]
        public GameObject prefabCoin;
        [Range(1, 1000)]
        public int coinCount;
        [Range(0f, 1f)]
        public float coinProbability;
    }
}