using UnityEngine;// �ޥ� unity �����C���R�W�Ŷ� �G�ܮw��θ�ƻP�\��

namespace grecty489
{
    // Unity ���O�n���楲����b�C������W
    /// <summary>
    /// �K�n�G���U����
    /// First Scripts �Ĥ@�Ӹ}�� �ǲ� C# ��¦�P Unity
    /// </summary>
    public class FirstScripts : MonoBehaviour
    {
        #region ��ưϰ�
        // ���
        #endregion
        
        #region �ƥ�ϰ�GUnity �J�f
        /// <summary>
        /// ����ƥ�G�C���}�l�ɦb Star ���e�|����@��
        /// </summary>
        private void Awake()
        {
            print("���o�AWorld�I:D");
        }
        /// <summary>
        /// �}�l�ƥ�G�C���}�l�ɦb Awark ����|����@��
        /// </summary>
        private void Start()
        {
            print("�}�l�ƥ�I");
            // Rich Text
            print("<color=orange>����r</color>");
            print("<color=#ff7f50>�����</color>");
        }
        #endregion
    }
}
