using UnityEngine;

namespace grecty489
{ 
    /// <summary>
    /// 學習非靜態 API
    /// Properties
    /// Public Methods
    /// </summary>
   public class AIPNonStatic : MonoBehaviour
   {
        // 靜態：static 存在記憶體內，跟遊戲物件無關
        //Time、Random

        //非靜態：預設不存在記憶體內，跟遊戲物件有關
        //Transfrom

        //1. 非靜態屬性 Properties

        //1-1 取得 Get
        //語法：
        //步驟一：定義欄位儲存遊戲物件
        //欄位名稱.非靜態屬性

        //步驟二：確定該物件有此元件
        //例如：燈光 Light

        public Transform traA;
        public Light lightA;

        public Transform traPlayer;
        public Camera camMain;

        public Transform traBat;

        //1-2 設定 Set
        //語法：
        //欄位名稱：非靜態屬性 指定 值;

        //2. 非靜態方法 Public Methods
        //語法：
        //欄位名稱：非靜態方法(對應的引數);

        private void Awake()
        {
            print("座標：" + traA.position);

            print("燈光顏色：" + lightA.color);

            //唯獨屬性不能設定
            //traPlayer.lossyScale = Vector3.one * 3;

            traPlayer.localScale = Vector3.one * 3;

            camMain.depth = 7;
            print("攝影機深度：" + camMain.depth);
        }

            public BoxCollider cube;
            public AudioSource aud;
            public Canvas canvas;

            public Rigidbody rigSphere;

            public Transform traCube;
            public Transform traSphere;
            public Transform traCapsule;

        private void Start()
        {

            print("立方體碰撞器尺寸：" + cube.size);
            print("音源音量：" + aud.volume);
            print("畫布渲染模式：" + canvas.renderMode);

            cube.center = new Vector3(1, 3, 1);
            aud.volume = 0.5f;
            canvas.renderMode = RenderMode.WorldSpace;

            rigSphere.AddForce(0, 1500, 0);
        }

        private void Update()
        {
            traBat.Rotate(0, 30, 0);

            traCube.LookAt(traSphere);

            traCapsule.Translate(0, 0, 3);
        }
    }

}
