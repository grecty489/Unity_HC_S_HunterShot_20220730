using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

namespace grecty489
{
    /// <summary>
    /// 傷害系統：產生傷害值物件，更新傷害值與動畫效果
    /// </summary>
    public class DamageSystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("畫布傷害值")]
        private GameObject prefabDamage;
        [SerializeField, Header("傷害值位移")]
        private Vector3 offsetDamge;
        [SerializeField, Header("動畫控制器")]
        private Animator ani;
        [SerializeField, Header("血條")]
        private Image imgHp;
        [SerializeField, Header("文字血量")]
        private TextMeshProUGUI textHp;

        [SerializeField, Header("是否為玩家物件")]
        private bool isPlayer;

        [Space(20)]
        [SerializeField, Header("怪物資料")]
        private DataEnemy dataEnemy;
        [SerializeField, Header("怪物碰撞器")]
        private BoxCollider boxCollider;
        [SerializeField, Header("怪物模型")]
        private GameObject modelEnemy;

        private float hp;
        private float hpMax;
        private string parDamage = "觸發傷害";
        private string nameMarble = "彈珠";
        private TextMeshProUGUI textDamage;
        private PlayerData playerData;
        #endregion

        private TurnSystem TurnSystem;
        private ControlSystem ControlSystem;

        #region 事件
        private void Awake()
        {
            TurnSystem = FindObjectOfType<TurnSystem>();
            ControlSystem = FindObjectOfType<ControlSystem>();
            playerData = GameObject.Find("士兵").GetComponent<PlayerData>();

            if (!isPlayer) hp = dataEnemy.hp;
            else if (isPlayer) hp = playerData.hp;

            hpMax = hp;
            UpdateUI();

            // SpawnDamegeObject();
        }

        // 碰撞開始事件：兩個物件碰撞時執行一次
        private void OnCollisionEnter(Collision collision)
        {
            // print("碰到的物件：" + collision.gameObject);

            // 如果 碰撞.物件.名稱 包含(彈珠) 就 生成傷害物件
            if (collision.gameObject.name.Contains(nameMarble))
            {
                SpawnDamegeObject();
            }
        }

        // 碰撞開始事件：兩個物件碰撞結束執行一次
        private void OnCollisionExit(Collision collision)
        {

        }

        // 碰撞開始事件：兩個物件碰撞器重疊時持續執行
        private void OnCollisionStay(Collision collision)
        {

        } 
        #endregion

        /// <summary>
        /// 玩家受到傷害
        /// </summary>
        /// <param name="damage">傷害值</param>
        public void PlayerGetDamage(float damage = 0)
        {
            SpawnDamegeObject(damage);
        }

        /// <summary>
        /// 玩家死亡
        /// </summary>
        private void PlayerDead()
        {
            TurnSystem.FadeInFinal("關卡失敗..");
            ControlSystem.enabled = false;
        }

        /// <summary>
        /// 生成傷害值物件
        /// </summary>
        private void SpawnDamegeObject(float damage = 0)
        {
            GameObject tempDamage = Instantiate(
                prefabDamage,
                transform.position + offsetDamge,
                Quaternion.Euler(60, 0, 0));

            textDamage = tempDamage.transform.Find("文字傷害值").GetComponent<TextMeshProUGUI>();

            float attack = playerData.attack;

            if (isPlayer) attack = damage;

            textDamage.text ="-" + attack;
            Damage(attack);

            StartCoroutine(AnimationEffect(tempDamage));
        }

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="attack">接受到的攻擊力</param>
        private void Damage(float attack) 
        {
            hp -= attack;
            ani.SetTrigger(parDamage);
            UpdateUI();

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// 死亡
        /// </summary>
        private void Dead()
        {
            hp = 0;

            if (isPlayer)
            {
                PlayerDead();
                return;               //如果 是 玩家就跳出
            }

            boxCollider.enabled = false;        // 關閉怪物格子的碰撞器
            modelEnemy.SetActive(false);        // 隱藏怪物模型

            // 刪除(物件，延遲時間)；
            // gameObject 此遊戲物件
            Destroy(gameObject, 2.5f);
            DropCoin();
        }

        private void DropCoin()
        {
            float random = Random.value;
            print($"金幣本次機率：{random}");

            if (random <= dataEnemy.coinProbability)
            {
                for (int i = 0; i < dataEnemy.coinCount; i++)
                {
                    GameObject tempCoin = Instantiate(
                        dataEnemy.prefabCoin,
                        transform.position + Vector3.up * 2,
                        Quaternion.Euler(90, 0, 0));

                    float randomX = Random.Range(-100, 100);
                    float randomZ = Random.Range(-100, 100);
                    tempCoin.GetComponent<Rigidbody>().AddForce(new Vector3(randomX, 250, randomZ));
                }
            }
        }

        /// <summary>
        /// 更新介面
        /// </summary>
        private void UpdateUI()
        {
            textHp.text = hp.ToString();
            imgHp.fillAmount = hp / hpMax;
        }

        /// <summary>
        /// 動畫效果
        /// </summary>
        /// <param name="tempDamage">傷害值物件</param>
        /// <returns></returns>
        private IEnumerator AnimationEffect(GameObject tempDamage)
        {
            StartCoroutine(Fade(tempDamage.GetComponent<CanvasGroup>()));

            yield return StartCoroutine(MoveDamage(tempDamage.GetComponent<RectTransform>()));

            yield return StartCoroutine(MoveDamage(tempDamage.GetComponent<RectTransform>(), false, 3));

            StartCoroutine(Fade(tempDamage.GetComponent<CanvasGroup>(), false));
        }

        /// <summary>
        /// 移動傷害值效果
        /// </summary>
        /// <param name="rectDamage">傷害值變形元件</param>
        /// <returns></returns>

        private IEnumerator MoveDamage(RectTransform rectDamage, bool isUP = true, int count = 10)
        {
            float increase = isUP ? +0.1f : -0.1f;

            for (int i = 0; i < count; i++)
            {
                rectDamage.anchoredPosition += new Vector2(0, increase);
                yield return new WaitForSeconds(0.03f);
            }
        }

        /// <summary>
        /// 淡入淡出
        /// </summary>
        /// <param name="group">群組元件</param>
        /// <param name="fadeIn">是否淡入</param>
        private IEnumerator Fade(CanvasGroup group,bool fadeIn = true)
        {
            // 三元運算子
            // 布林值 ? 布林值為 true : 布林值為 false;
            float increase = fadeIn ? +0.1f : -0.1f;    // 如果 淡入 就增加 +0.1 直到 -0.1

            for (int i = 0; i < 10; i++)
            {
                group.alpha += increase;                // 群組原件的透明度 逐增
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}

