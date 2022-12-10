using UnityEngine;

namespace grecty489
{
    /// <summary>
    /// �Ǫ���ơG�Ǫ���q�B�����O�B���_����B���v
    /// </summary>
    /// Scriptable Object �}���ƪ���
    /// �ت��G�N�}��������x�s�b Project ����K�޲z
    /// CAM �إ߯������
    /// menuName ���W�١G�D���/�����/�������/...
    /// fileName �ɮצW�١G��ĳ�ϥέ^��
    [CreateAssetMenu(menuName = "grecty489/Data Enemy", fileName = "New Data Enemy")]
    public class DataEnemy : ScriptableObject
    {
        [Header("���ݩ�")]
        [Range(1, 5000)]
        public float hp;
        [Range(1, 5000)]
        public float attack;
        [Space(20)]
        [Header("�������")]
        public GameObject prefabCoin;
        [Range(1, 1000)]
        public int coinCount;
        [Range(0f, 1f)]
        public float coinProbability;
    }
}