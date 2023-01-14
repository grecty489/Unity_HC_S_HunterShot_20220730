using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace grecty489
{
    /// <summary>
    /// 回合系統
    /// </summary>
    public class TurnSystem : MonoBehaviour
    {
        private TextMeshProUGUI textFinalTitle;
        private Button btnReplay, btnQuit;
        private CanvasGroup groupFinal;

        [SerializeField, Header("最大層數")]
        private int countFloorMax = 5;

        /// <summary>
        /// 層數數字
        /// </summary>
        private TextMeshProUGUI textFloorCount;
        private int countFloor = 1;

        [Header("敵人回合事件")]
        public UnityEvent onEnemyTurn;

        [SerializeField, Header("敵人回合多久生成下一波"), Range(0, 3)]
        private float timeToSpwanNextEnemy = 1.2f;
        [SerializeField, Header("生成多久回到玩家回合"), Range(0, 3)]
        private float timeToPlayerTurn = 0.8f;

        private SpawnSystem SpawnSystem;

        #region 資料
        public enum Turn { Player, Enemy }
        [SerializeField]
        private Turn turn;

        private string nameMarble = "彈珠";
        private int countRecycleMarble;
        private ControlSystem controlSystem; 
        #endregion

        private void Awake()
        {
            controlSystem = FindObjectOfType<ControlSystem>();
            SpawnSystem = FindObjectOfType<SpawnSystem>();

            textFloorCount = GameObject.Find("層數數字").GetComponent<TextMeshProUGUI>();

            textFinalTitle = GameObject.Find("結束標題").GetComponent<TextMeshProUGUI>();
            btnReplay = GameObject.Find("重新挑戰").GetComponent<Button>();
            btnQuit = GameObject.Find("結束遊戲").GetComponent<Button>();
            groupFinal = GameObject.Find("結束畫面").GetComponent<CanvasGroup>();

            // 黏巴達 => Lambda
            // Application.Quit() 應用程式.離開()
            btnQuit.onClick.AddListener(() => Application.Quit());
            // SceneManager.LoadScene("場景名稱") 場景管理器.載入場景("場景名稱")
            btnReplay.onClick.AddListener(() => SceneManager.LoadScene("關卡 1"));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains(nameMarble))
            {
                RecycleMarble();
            }
        }

        /// <summary>
        /// 淡入結束畫面
        /// </summary>
        /// <param name="title">要更新的標題</param>
        public void FadeInFinal(string title)
        {
            textFinalTitle.text = title;
            StartCoroutine(Fade());
        }

        private IEnumerator Fade()
        {
            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.02f);
            }

            groupFinal.interactable = true;                 // 畫布群組元件.互動 = 勾選 - 可互動
            groupFinal.blocksRaycasts = true;               // 畫布群組元件.遮擋 = 勾選 - 可被滑鼠選取
        }

        /// <summary>
        /// 回收彈珠
        /// </summary>
        private void RecycleMarble()   
        {
            countRecycleMarble++;

            if (countRecycleMarble == controlSystem.countShootMarble)
            {
                EnemyTurn();
            }
        }

        /// <summary>
        /// 敵人回合
        /// </summary>
        private void EnemyTurn() 
        {
            turn = Turn.Enemy;
            onEnemyTurn.Invoke();           //事件.呼叫()； - 讓事件執行

            if (countFloor < countFloorMax)
                Invoke("spawnNextEnemy", timeToSpwanNextEnemy);  //呼叫延遲("方法名稱"，延遲時間)
            else
                Invoke("PlayerTurn", timeToPlayerTurn);

            FindEnemys();
        }

        private void FindEnemys()
        {
            // 遊戲物件.透過標籤搜尋複數物件(標籤名稱) - 搜尋場景上指定標籤的物件並回傳陣列
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("怪物");
            // 如果 層數 為 最大層數 並且 敵人數量 為 零 就挑戰成功
            if (countFloor == countFloorMax && enemys.Length == 0) FadeInFinal("遊戲通關");
        }

        /// <summary>
        /// 生成下一波敵人
        /// </summary>
        private void spawnNextEnemy()
        {
            SpawnSystem.spwanEnemy();
            Invoke("PlayerTurn", timeToPlayerTurn);
        }

        /// <summary>
        /// 玩家回合
        /// </summary>
        private void PlayerTurn()
        {
            turn = Turn.Player;
            countRecycleMarble = 0;
            controlSystem.isShooted = false;

            controlSystem.countShootMarble += controlSystem.addMarbleThisTurn;
            controlSystem.addMarbleThisTurn = 0;

            if (countFloor < countFloorMax)
            {
                countFloor++;                                   //層數遞增
                textFloorCount.text = countFloor.ToString();    //層數數字更新
            }
        }
    }
}

