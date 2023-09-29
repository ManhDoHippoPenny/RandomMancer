﻿using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace GridManager
{
    public class GridManager : Singleton<GridManager>
    {
        [SerializeField] private int _width, _height;

        [SerializeField] private Grid _tilePrefab;
        public GameObject _holder;
        public Dictionary<Vector2, Grid> _mapGrids = new Dictionary<Vector2, Grid>();
        
        private void Start()
        {
            GenerateGrid();
        }

        void GenerateGrid()
        {
            for (int i = 0; i < _width; ++i)
            {
                for (int j = 0; j < _height; ++j)
                {
                    var spawnedTile = Instantiate(_tilePrefab, new Vector3(i * _tilePrefab.transform.localScale.x,
                        _tilePrefab.transform.localScale.y,j * _tilePrefab.transform.localScale.z) + _holder.transform.position, Quaternion.identity);
                    //Debug.Log(spawnedTile.transform.position);
                    spawnedTile.transform.gameObject.SetActive(true);
                    spawnedTile.name = $"Tile {i} {j}";
                    spawnedTile.transform.SetParent(_holder.transform);
                    _mapGrids.Add(new Vector2(i+1,j+1),spawnedTile);
                    bool isOffset = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);
                    spawnedTile.Init(isOffset); 
                }
            }
        }
    }
}