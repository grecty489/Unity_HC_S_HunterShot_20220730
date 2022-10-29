using UnityEngine;

namespace grecty489
{ 
    /// <summary>
    /// �ǲ߫D�R�A API
    /// Properties
    /// Public Methods
    /// </summary>
   public class AIPNonStatic : MonoBehaviour
   {
        // �R�A�Gstatic �s�b�O���餺�A��C������L��
        //Time�BRandom

        //�D�R�A�G�w�]���s�b�O���餺�A��C��������
        //Transfrom

        //1. �D�R�A�ݩ� Properties

        //1-1 ���o Get
        //�y�k�G
        //�B�J�@�G�w�q����x�s�C������
        //���W��.�D�R�A�ݩ�

        //�B�J�G�G�T�w�Ӫ��󦳦�����
        //�Ҧp�G�O�� Light

        public Transform traA;
        public Light lightA;

        public Transform traPlayer;
        public Camera camMain;

        public Transform traBat;

        //1-2 �]�w Set
        //�y�k�G
        //���W�١G�D�R�A�ݩ� ���w ��;

        //2. �D�R�A��k Public Methods
        //�y�k�G
        //���W�١G�D�R�A��k(�������޼�);

        private void Awake()
        {
            print("�y�СG" + traA.position);

            print("�O���C��G" + lightA.color);

            //�߿W�ݩʤ���]�w
            //traPlayer.lossyScale = Vector3.one * 3;

            traPlayer.localScale = Vector3.one * 3;

            camMain.depth = 7;
            print("��v���`�סG" + camMain.depth);
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

            print("�ߤ���I�����ؤo�G" + cube.size);
            print("�������q�G" + aud.volume);
            print("�e����V�Ҧ��G" + canvas.renderMode);

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
