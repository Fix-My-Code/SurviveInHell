using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace LogicSceneContext
{
    public class ChunkGenerator : MonoBehaviour
    {
        [SerializeField]
        private int chunkScale = 32;

        [SerializeField]
        private GameObject prefab;

        private Dictionary<Vector2, GameObject> _chunkMap = new Dictionary<Vector2, GameObject>();
        private Vector2 _currentChunk;

        private List<Vector2Int> _directions = new List<Vector2Int>()
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 1),
            new Vector2Int(1, 0),
            new Vector2Int(1, -1),
            new Vector2Int(0, -1),
            new Vector2Int(-1, -1),
            new Vector2Int(-1, 0),
            new Vector2Int (-1, 1)
        };

        private void Start()
        {
            _currentChunk = new Vector2(Mathf.Round(Camera.main.transform.position.x / chunkScale), Mathf.Round(Camera.main.transform.position.y / chunkScale));
            var chunk = Instantiate(prefab, new Vector3(_currentChunk.x, _currentChunk.y, 0), Quaternion.identity);
            _chunkMap.Add(_currentChunk, chunk);
            StartCoroutine(UpdatePosition());
        }

        private IEnumerator UpdatePosition()
        {
            while (true)
            {
                _currentChunk = new Vector2(Mathf.Round(Camera.main.transform.position.x / chunkScale), Mathf.Round(Camera.main.transform.position.y / chunkScale));
                foreach (var chunk in _chunkMap)
                {
                    var delta = _currentChunk - chunk.Key;
                    if (delta.magnitude > 2)
                    {
                        chunk.Value.SetActive(false);
                    }
                }
                StartCoroutine(ChunkGenerate());
                yield return new WaitForSeconds(1);
            }
        }

        private IEnumerator ChunkGenerate()
        {
            foreach (var direction in _directions)
            {
                if (!_chunkMap.ContainsKey(_currentChunk + direction))
                {
                    var spawnPoint = _currentChunk * chunkScale + new Vector2Int((int)chunkScale * direction.x, (int)chunkScale * direction.y);
                    var chunk = Instantiate(prefab, new Vector3(spawnPoint.x, spawnPoint.y, 0), Quaternion.identity);
                    _chunkMap.Add(_currentChunk + direction, chunk);
                    yield return new WaitForSeconds(0.3f);
                } else if (_chunkMap.TryGetValue(_currentChunk + direction, out var chunk))
                {
                    chunk.SetActive(true);
                }

            }
        }
    }
}