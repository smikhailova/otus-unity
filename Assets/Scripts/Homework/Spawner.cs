using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework
{
    /**
     * TODO:
     * 1. Найти примеры полиморфизма в уже написанном коде и в том, что будет написан вами. +
     *      - абстрактный класс Move и виртуальная ф-я Execute в нём
     *      - интерфейсы IColorChangeable и IBarkable и ф-ии в них
     *      - перегрузка методов Walk и Run в соответствующих классах
     * 2. Реализовать удаление объектов из коллекции _spawnedObjects. +
     * 3. Заменить тип коллекции на более подходящий к данному случаю. Объяснить, если замена не требуется. +
     *      - думаю, что замена не требуется
     *      - с одной стороны у нас ограничено количество объектов, которые могут быть заспавнены - в таком случае
     *      для большей производительности стоит использовать Array. Однако, у нас есть задание реализовать
     *      удаление объектов из коллекции, в таком случае удобнее использовать List.
     *      Если использовать Array, то при удалении элемента будут образовываться гапы, тогда надо будет
     *      либо написать метод, который ищет гап и вставляет новый элемент туда, либо подстраивать спавн под удаление,
     *      а это уже будет не гибкое решение, либо делать ресайзинг, что тоже по сути будет создавать новый массив
     *      и это снизит разницу в производительности
     */
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private int _totalAmount;

        [SerializeField]
        private float _spawnDelay;

        [SerializeField]
        private float _deleteDelay;

        [SerializeField]
        private List<GameObject> _objectsToSpawn;

        private readonly List<GameObject> _spawnedObjects = new();


        void Start()
        {
            StartCoroutine(SpawnNext());
            StartCoroutine(DeleteRandomSpawned());
        }

        private IEnumerator SpawnNext()
        {
            var random = new System.Random();
            int i;

            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);

                if (_spawnedObjects.Count < _totalAmount)
                {
                    i = random.Next(_objectsToSpawn.Count);

                    var spawnedObject = Instantiate(_objectsToSpawn[i], transform);

                    _spawnedObjects.Add(spawnedObject);
                }
            }
        }

        private IEnumerator DeleteRandomSpawned()
        {
            var random = new System.Random();
            int spawnedObjectToDelete;

            while (true)
            {
                yield return new WaitForSeconds(_deleteDelay);

                if (_spawnedObjects.Count != 0)
                {
                    spawnedObjectToDelete = random.Next(_spawnedObjects.Count - 1);

                    Destroy(_spawnedObjects[spawnedObjectToDelete]);
                    _spawnedObjects.RemoveAt(spawnedObjectToDelete);
                }
            }
        }
    }
}