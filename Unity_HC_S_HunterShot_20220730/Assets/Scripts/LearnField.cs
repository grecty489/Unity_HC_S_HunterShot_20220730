using UnityEngine;

namespace grecty489
{
    /// <summary>
    /// 學習欄位 Field
    /// </summary>
    public class LearnField : MonoBehaviour
    {
        #region 欄位語法、修飾詞與四大類型
        // 欄位語法：
        // 修飾詞 資料類型 欄位名稱;
        private int number;

        // 修飾詞 資料類型 欄位名 指定 值;
        private int level = 1;

        // 私人：此類別可以存取，不會顯示在屬性面板
        private int scoreA = 60;

        // 公開：所有類別可以存取，會顯示在屬性面板
        // 整數 int
        public int scoreB = 90;
        // 浮點數 float
        public float speed = 3.5f;
        // 字串 string
        public string weapon = "火箭筒";
        // 布林值 bool
        public bool isDead = false;
        public bool isGrounded = true;
        #endregion

        #region Unity 常用類型
        // 向量 Vector
        public Vector2 v2Position;
        public Vector2 v2One = Vector2.one;
        public Vector2 v2Custom = new Vector2(3.5f, 7.1f);

        public Vector3 v3Custom = new Vector3(1, 2, 3);
        public Vector4 v4Custom = new Vector4(1.1f, 2.2f, 3.3f, 4.4f);

        // 顏色 Color
        public Color colorDefault;                                 // 透明黑
        public Color colorRed = Color.red;                         // 純紅
        public Color colorCustom = new Color(1, 0, 1);             // 紅+藍
        public Color colorCustomRGBA = new Color(1, 1, 0, 0.5f);   // 半透明紅+綠

        // 列舉資料：按鍵
        public KeyCode keyA = KeyCode.A;
        public KeyCode keyJump = KeyCode.Space;
        public KeyCode keyAttack = KeyCode.Mouse0;

        // 素材類型：儲存音效、圖片、材質球等素材資料
        // 不能指定值，只能透過 API 取得或屬性面板拖曳
        public AudioClip soundAttack;
        public Sprite pictureWin;
        public Material materialDissolve;

        // 遊戲物件：階層面板與專案內的物件或預製物
        public GameObject goSoldier;
        public GameObject prefabMarble;

        //元件：遊戲物件上的任何元件皆可儲存
        public ParticleSystem psLight;
        public Camera mainCamera;
        #endregion

        private void Awake()
        {
            // 取 取得資料 get
            // 欄位名稱
            // 以 Unity 屬性面板為主
            print(level);
            print("速度" + speed);

            // 存 存放資料 set
            // 欄位名稱 指定 值;
            weapon = "手榴彈";
            scoreB = 30;
            speed = 5.5f;
            isDead = true;
        }
    }
}

