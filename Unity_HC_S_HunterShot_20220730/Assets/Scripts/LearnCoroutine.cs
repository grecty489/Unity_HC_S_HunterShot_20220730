using UnityEngine;
using System.Collections;

namespace grecty489 
{
    /// <summary>
    /// �ǲ߰��P�{��
    /// </summary>
    public class LearnCoroutine : MonoBehaviour
    {
        // �� ���{������
        // 1. �ޥ� �t�ζ��X �R�W�Ŷ�
        // 2. �w�q�^�� IEunmerator ����k
        // 3. �ϥ� StartCoroutine �Ұ�

        private void Awake()
        {
            StartCoroutine(Test());
;        }

        private IEnumerator Test() 
        {
            print("�Ĥ@�q�{��");
            yield return new WaitForSeconds(2);
            print("�������A�ĤG�q�{��");
        }
    }
}


