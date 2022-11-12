using UnityEngine;
using System.Collections;

namespace grecty489
{
    /// <summary>
    /// 控制系統
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        #region 資料
        [Header("基本資料")]
        [SerializeField, Range(0, 50)]
        private float Speed = 10.5f;
        [SerializeField]
        private int countShootMarble = 10;
        [SerializeField, Range(0, 5000)]
        private int SpeedMarble = 1500;
        [SerializeField, Range(0, 3)]
        private float intervalShoot = 0.5f;
        [SerializeField, Header("彈珠欲製物")]
        private GameObject prefabMarble;
        [SerializeField, Header("彈珠生成點")]
        private Transform pointSpwan;
        [SerializeField, Header("箭頭")]
        private GameObject goArrow;

        [SerializeField, Header("地板圖層")]
        private LayerMask layerGround;
        [SerializeField, Header("射線碰撞點的物件")]
        private Transform traTarget;

        private string perAttact = "觸發攻擊";
        private Animator ani;
        private bool isShooted;
        #endregion

        private void Awake()
        {
            //  取得元件<泛型>()
            //  動畫 = 取得元件<動畫>()
            ani = GetComponent<Animator>();

            
        }

        private void Update()
        {
            ShootMarble();
            TurnCharacter();
        }

        #region 方法
        /// <summary>
        /// 旋轉角色
        /// </summary>
        private void TurnCharacter()
        {
            if (isShooted) return;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Vector3 posMosue = Input.mousePosition;

                //print("<color=yellow>滑鼠座標：" + posMosue + "</color>");

                // Camera main = Camera.main;
                // main.ScreenPointToRay(posMosue);

                // 射線 = 主要攝影機.螢幕座標轉為射線(滑鼠座標);
                Ray ray = Camera.main.ScreenPointToRay(posMosue);

                RaycastHit hit;

                // 物理.射線碰撞(射線，距離，圖層);
                // print(Physics.Raycast(ray, 100, layerGround));

                if (Physics.Raycast(ray, out hit, 100, layerGround))
                {
                    print("射線碰撞點的物件：" + hit.point);

                    traTarget.position = hit.point;

                    transform.LookAt(traTarget);
                }

            }

        }

        /// <summary>
        /// 發射彈珠
        /// </summary>
        private void ShootMarble() 
        {
            // 如果 已經發射過 就 跳出
            if (isShooted) return;

            // Mouse0 可以抓到 PC 的滑鼠左鍵以及 Mobile 的觸控
            if (Input.GetKeyDown(KeyCode.Mouse0))        // 如果 按下 滑鼠左鍵
            {
                goArrow.SetActive(true);                  // 箭頭.顯示
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))     // 如果 放開 滑鼠左鍵
            {
                goArrow.SetActive(false);                 // 箭頭.隱藏
                isShooted = true;
                StartCoroutine(SpawnMarble(countShootMarble));
            }
        }

        /// <summary>
        /// 生成彈珠
        /// </summary>
        /// <param name="countToSpwan">要生成的彈珠數量</param>
        private IEnumerator SpawnMarble(int countToSpwan) 
        {
            // Objet.Instantiate();     //第一種寫法，Static
            // Instantiate();            //第二種寫法，繼承類別

            for (int i = 0; i < countToSpwan; i++)
            { 
                // 生成的彈珠 = 生成(物件，座標，角度)
                GameObject tempMarble = Instantiate(prefabMarble, pointSpwan.position, pointSpwan.rotation);
                // 生成的彈珠.取得元件<鋼體>().添加推力(三維向量)
                // 依照世界座標的 Z 軸發射
                // tempMarble.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, SpeedMarble));

                // transform 此物件的變形元件
                // 下方三個為 Vector3
                // 前方 transform.forward 此物件的 Z 軸
                // 右方 transform.right 此物件的 X 軸
                // 上方 transform.up 此物件的 Y 軸

                // 依照角色的 Z 軸發射
                tempMarble.GetComponent<Rigidbody>().AddForce(transform.forward * SpeedMarble);

                ani.SetTrigger(perAttact);
                yield return new WaitForSeconds(intervalShoot);
            }
        }
        #endregion
        
    }
}



