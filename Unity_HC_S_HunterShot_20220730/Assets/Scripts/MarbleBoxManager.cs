using UnityEngine;

namespace grecty489
{
    /// <summary>
    /// �u�]��l�޲z���G�P�_�Q�u�]�I���K�[�u�]�W��
    /// </summary>
    public class MarbleBoxManager : MonoBehaviour
    {
        private ControlSystem ControlSystem;
        private string nameMarble = "�u�]";

        private void Awake()
        {
            ControlSystem = GameObject.Find("�h�L").GetComponent<ControlSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // print($"<color=#2266ff>�I��u�]��l������G{ other.name}</color>");

            if (other.name.Contains(nameMarble))
            {
                ControlSystem.addMarbleThisTurn++;
                Destroy(gameObject);
            }
        }
    }
}


