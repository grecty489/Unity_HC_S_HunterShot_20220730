using UnityEngine;// 引用 unity 引擎遊戲命名空間 ：倉庫實用資料與功能

namespace grecty489
{
    // Unity 類別要執行必須放在遊戲物件上
    /// <summary>
    /// 摘要：輔助說明
    /// First Scripts 第一個腳本 學習 C# 基礎與 Unity
    /// </summary>
    public class FirstScripts : MonoBehaviour
    {
        #region 資料區域
        // 資料
        #endregion
        
        #region 事件區域：Unity 入口
        /// <summary>
        /// 喚醒事件：遊戲開始時在 Star 之前會執行一次
        /// </summary>
        private void Awake()
        {
            print("哈囉，World！:D");
        }
        /// <summary>
        /// 開始事件：遊戲開始時在 Awark 之後會執行一次
        /// </summary>
        private void Start()
        {
            print("開始事件！");
            // Rich Text
            print("<color=orange>橘色文字</color>");
            print("<color=#ff7f50>珊瑚紅</color>");
        }
        #endregion
    }
}
