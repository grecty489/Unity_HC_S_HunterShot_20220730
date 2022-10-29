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

        private string perAttact = "觸發攻擊";
        private Animator ani;
        #endregion

        private void Awake()
        {
            //  取得元件<泛型>()
            //  動畫 = 取得元件<動畫>()
            ani = GetComponent<Animator>();

            StartCoroutine(SpawnMarble(countShootMarble));
        }

        #region 方法
        /// <summary>
        /// 旋轉角色
        /// </summary>
        private void TurnCharacter()
        {
            
        }

        /// <summary>
        /// 發射彈珠
        /// </summary>
        private void ShootMarble() 
        {
            
        }

        /// <summary>
        /// 生成彈珠
        /// </summary>
        /// <param name="countToSpwan">要生成的彈珠數量</param>
        private IEnumerator SpawnMarble(int countToSpwan) 
        {
            // Objet.Instantiate();     //第一種寫法，Static
            //Instantiate();            //第二種寫法，繼承類別

            for (int i = 0; i < countToSpwan; i++)
            { 
                //生成(物件，座標，角度)
                Instantiate(prefabMarble, pointSpwan.position, pointSpwan.rotation);
                ani.SetTrigger(perAttact);
                yield return new WaitForSeconds(intervalShoot);
            }
        }
        #endregion
        
    }
}



