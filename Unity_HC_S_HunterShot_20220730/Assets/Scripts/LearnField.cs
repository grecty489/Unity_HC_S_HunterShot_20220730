using UnityEngine;

namespace grecty489
{
    /// <summary>
    /// �ǲ���� Field
    /// </summary>
    public class LearnField : MonoBehaviour
    {
        #region ���y�k�B�׹����P�|�j����
        // ���y�k�G
        // �׹��� ������� ���W��;
        private int number;

        // �׹��� ������� ���W ���w ��;
        private int level = 1;

        // �p�H�G�����O�i�H�s���A���|��ܦb�ݩʭ��O
        private int scoreA = 60;

        // ���}�G�Ҧ����O�i�H�s���A�|��ܦb�ݩʭ��O
        // ��� int
        public int scoreB = 90;
        // �B�I�� float
        public float speed = 3.5f;
        // �r�� string
        public string weapon = "���b��";
        // ���L�� bool
        public bool isDead = false;
        public bool isGrounded = true;
        #endregion

        #region Unity �`������
        // �V�q Vector
        public Vector2 v2Position;
        public Vector2 v2One = Vector2.one;
        public Vector2 v2Custom = new Vector2(3.5f, 7.1f);

        public Vector3 v3Custom = new Vector3(1, 2, 3);
        public Vector4 v4Custom = new Vector4(1.1f, 2.2f, 3.3f, 4.4f);

        // �C�� Color
        public Color colorDefault;                                 // �z����
        public Color colorRed = Color.red;                         // �¬�
        public Color colorCustom = new Color(1, 0, 1);             // ��+��
        public Color colorCustomRGBA = new Color(1, 1, 0, 0.5f);   // �b�z����+��

        // �C�|��ơG����
        public KeyCode keyA = KeyCode.A;
        public KeyCode keyJump = KeyCode.Space;
        public KeyCode keyAttack = KeyCode.Mouse0;

        // ���������G�x�s���ġB�Ϥ��B����y���������
        // ������w�ȡA�u��z�L API ���o���ݩʭ��O�즲
        public AudioClip soundAttack;
        public Sprite pictureWin;
        public Material materialDissolve;

        // �C������G���h���O�P�M�פ�������ιw�s��
        public GameObject goSoldier;
        public GameObject prefabMarble;

        //����G�C������W�����󤸥�ҥi�x�s
        public ParticleSystem psLight;
        public Camera mainCamera;
        #endregion

        private void Awake()
        {
            // �� ���o��� get
            // ���W��
            // �H Unity �ݩʭ��O���D
            print(level);
            print("�t��" + speed);

            // �s �s���� set
            // ���W�� ���w ��;
            weapon = "��h�u";
            scoreB = 30;
            speed = 5.5f;
            isDead = true;
        }
    }
}

