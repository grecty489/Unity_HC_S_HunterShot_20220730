using UnityEngine;

namespace grecty489
{
    /// <summary>
    /// 彈珠格子管理器：判斷被彈珠碰到後添加彈珠上限
    /// </summary>
    public class MarbleBoxManager : MonoBehaviour
    {
        private ControlSystem ControlSystem;
        private string nameMarble = "彈珠";

        private void Awake()
        {
            ControlSystem = GameObject.Find("士兵").GetComponent<ControlSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // print($"<color=#2266ff>碰到彈珠格子的物件：{ other.name}</color>");

            if (other.name.Contains(nameMarble))
            {
                ControlSystem.addMarbleThisTurn++;
                Destroy(gameObject);
            }
        }
    }
}


