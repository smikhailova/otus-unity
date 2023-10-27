using System.Collections;
using System.Linq;
using UnityEngine;

namespace Game.Scripts
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private Character[] _players;
        [SerializeField]
        private Character[] _enemies;

        [SerializeField]
        private Weapon _sniperRifle;

        private readonly Queue _turns = new();

        private bool _isTargetSelectionConfirmed;
        private Character _selectedTarget;

        [SerializeField]
        private EndScreenManager _endScreenManager;


        private void Start()
        {
            foreach (var player in _players)
            {
                _turns.Enqueue(player);
            }

            foreach (var enemy in _enemies)
            {
                _turns.Enqueue(enemy);
            }

            StartCoroutine(LevelLoop());
        }

        private IEnumerator LevelLoop()
        {
            foreach (var turn in GetTurns())
            {
                if (turn is Character character)
                {
                    if (character.IsAlive)
                    {
                        var isPlayer = _players.Contains(character);
                        var opponent = GetTarget(_players);
                        yield return StartCoroutine(isPlayer
                            ? PlayerMove(character)
                            : EnemyMove(character, opponent)
                        );

                        _turns.Enqueue(character);
                    }
                }
                else if (turn is Weapon weapon)
                {
                    var opponent = GetTarget(_enemies);
                    yield return StartCoroutine(WeaponMove(weapon, opponent));
                }

                if (!AnyCharacterAlive(_enemies))
                {
                    GameWon();
                    yield break;
                }

                if (!AnyCharacterAlive(_players) || !AnyCharacterAlive(_enemies))
                {
                    GameLost();
                    yield break;
                }
            }
        }

        private void GameWon()
        {
            Debug.Log($"{GetType().Name}.GameWon:");
            _endScreenManager.ShowWinScreen();
        }

        private void GameLost()
        {
            Debug.Log($"{GetType().Name}.GameLost:");
            _endScreenManager.ShowGameOverScreen();
        }

        private IEnumerable GetTurns()
        {
            while (true)
            {
                var attacker = _turns.Dequeue();
                yield return attacker;
            }
        }

        private Character GetTarget(Character[] characters)
        {
            return characters.First(character => character.IsAlive);
        }

        private bool AnyCharacterAlive(Character[] characters)
        {
            return characters.Any(character => character.IsAlive);
        }

        private IEnumerator PlayerMove(Character player)
        {
            _isTargetSelectionConfirmed = false;

            SelectRandomEnemy();

            yield return new WaitUntil(() => _isTargetSelectionConfirmed);

            yield return player.Attack(_selectedTarget);

            yield return new WaitForSeconds(2f);
        }

        private IEnumerator EnemyMove(Character enemy, Character player)
        {
            if (!player) yield break;

            Vector3 initialPos = CopyPosition(enemy.transform.position);

            yield return MoveToTarget(enemy, player.transform.position, 1.2f, 2f);

            yield return enemy.Attack(player);

            yield return MoveToTarget(enemy, initialPos, 0.1f, 1f);

            enemy.SetTarget(player.transform.position);
            yield return new WaitForSeconds(2f);

            yield break;
        }

        private IEnumerator MoveToTarget(Character character, Vector3 targetPosition, float moveDelta, float waitTime)
        {
            character.SetTarget(targetPosition);
            character.Move(moveDelta);
            yield return new WaitForSeconds(waitTime);
        }

        private Vector3 CopyPosition(Vector3 position)
        {
            float x = position.x;
            float y = position.y;
            float z = position.z;

            return new(x, y, z);
        }

        public void CallSniper()
        {
            if (_turns.Contains(_sniperRifle)) return;

            _turns.Enqueue(_sniperRifle);
        }

        public IEnumerator WeaponMove(Weapon weapon, Character target)
        {
            Debug.Log($"{GetType().Name}.WeaponMove:");
            target.TakeDamage(weapon.Damage);
            yield return new WaitForSeconds(2f);
        }

        public void ConfirmTargetSelection()
        {
            _isTargetSelectionConfirmed = true;
        }

        public void SelectRandomEnemy()
        {
            var nextEnemies = _enemies.Where(character => character.IsAlive && character != _selectedTarget);

            if (nextEnemies.Count() == 0) return;

            _selectedTarget = nextEnemies.ToArray()[Random.Range(0, nextEnemies.Count())];
        }
    }
}