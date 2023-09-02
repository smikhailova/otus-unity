using System.Collections;
using UnityEngine;

namespace Game.Scripts
{
    public class GameController : MonoBehaviour
    {
        public Character player;
        public Character enemy;

        
        private IEnumerator Start()
        {
            while (true)
            {
                if (player.Health > 0 && enemy.Health > 0)
                {
                    yield return StartCoroutine(PlayerMove());
                }
                
                if (player.Health > 0 && enemy.Health > 0)
                {
                    yield return StartCoroutine(EnemyMove());
                }
                
                if (player.Health == 0 || enemy.Health == 0)
                {
                    Debug.Log($"{GetType().Name}.Start: player.Health = {player.Health}, enemy.Health = {enemy.Health}");
                    
                    yield break;
                }
            }
        }

        private IEnumerator PlayerMove()
        {
            yield return player.Attack(enemy);
            yield break;
        }

        private IEnumerator EnemyMove()
        {
            Vector3 initialPos = CopyPosition(enemy.transform.position);

            yield return MoveToTarget(player.transform.position, 1.2f, 2f);

            yield return enemy.Attack(player);

            yield return MoveToTarget(initialPos, 0.1f, 1f);

            enemy.SetTarget(player.transform.position);
            yield return new WaitForSeconds(2f);

            yield break;
        }

        private IEnumerator MoveToTarget(Vector3 targetPosition, float moveDelta, float waitTime)
        {
            enemy.SetTarget(targetPosition);
            enemy.Move(moveDelta);
            yield return new WaitForSeconds(waitTime);
        }

        private Vector3 CopyPosition(Vector3 position)
        {
            float x = position.x;
            float y = position.y;
            float z = position.z;

            return new(x, y, z);
        }
    }
}