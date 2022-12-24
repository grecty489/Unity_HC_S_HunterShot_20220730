using UnityEngine;

namespace grecty489
{
    /// <summary>
    /// 金幣管理：飛到指定位置並儲存
    /// </summary>
    public class CoinManager : MonoBehaviour
    {
        [SerializeField, Header("飛行速度"), Range(0, 500)]
        private float speedFly = 3.5f;

        /// <summary>
        /// 金幣要飛往的目的地
        /// </summary>
        private Transform pointTarget;
        private CoinSystem coinSystem;

        private void Awake()
        {
            pointTarget = GameObject.Find("金幣要飛往的目的地").transform;
            coinSystem = GameObject.Find("金幣系統").GetComponent<CoinSystem>();
        }

        private void Update()
        {
            FlyToTarget();
        }

        private void FlyToTarget()
        {
            // 階段座標 = 三維向量.向前移動(當前座標，目標座標，移動單位);
            Vector3 pos = Vector3.MoveTowards(transform.position, pointTarget.position, speedFly * Time.deltaTime);
            // 此物件變形元件 的 座標 = 階段座標
            transform.position = pos;

            // 距離 = 三圍向量.距離(當前座標，目標座標)；
            float dis = Vector3.Distance(transform.position, pointTarget.position);

            // 如果 距離 小於 1 就刪除
            if (dis < 1)
            {
                coinSystem.UpdataCoin();
                Destroy(gameObject);
            }
        }
    }
}
