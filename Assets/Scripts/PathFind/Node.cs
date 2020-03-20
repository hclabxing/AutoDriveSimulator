﻿/// Author : Humor Logic 雍
/// URL : http://www.humorlogic.com/
/// Github : https://github.com/HumorLogic

#region Includes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace AutoDriveSimulator
{

    /// <summary>
    /// Node Class Type
    /// </summary>
    public enum NodeType
    {
        Normal,
        Obsticle,
        Start,
        Destination
    }


    /// <summary>
    /// Node Class
    /// </summary>
    public class Node
    {

        #region Members
        public NodeType NodeType { get; set; }
        public NodeGrid Grid { get; private set; }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public Vector2 Pos { get; private set; }
        public bool isStepped { get; set; }
        public bool isMarked { get; set; }
        public string Name { get; private set; }

        public int gValue { get; set; }
        public GameObject nodeObj { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Node class constructor
        /// </summary>
        /// <param name="grid">NodeGrid class object</param>
        /// <param name="row">the node‘s row</param>
        /// <param name="col">the node's col</param>
        /// <param name="type">Node type</param>
        public Node(NodeGrid grid, int row, int col, NodeType type)
        {
            Grid = grid;
            Row = row;
            Col = col;
            NodeType = type;
            Pos = new Vector2(Row, Col);
            Name = $"Node({Row},{Col})";
            isStepped = false;
            isMarked = false;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Initial Node object method
        /// </summary>
        /// <param name="parent">node's parent transform in Unity</param>
        /// <param name="prefab">node's prefab</param>
        public void InitNode(Transform parent, GameObject prefab)
        {
            nodeObj = GameObject.Instantiate(prefab);
            nodeObj.name = Name;
            nodeObj.transform.parent = parent;
            nodeObj.transform.position = new Vector3(Col, -Row, 0);
        }


        /// <summary>
        /// Set node's color
        /// </summary>
        /// <param name="color">color</param>
        public void SetColor(Color color)
        {
            nodeObj.GetComponent<SpriteRenderer>().color = color;
        }


        /// <summary>
        /// Set the cost for this node
        /// </summary>
        /// <param name="gValue">cost value</param>
        public void SetCost(int gValue)
        {
            this.gValue = gValue;
            nodeObj.GetComponentInChildren<Text>().text = gValue.ToString();
        }

        #endregion
    }

}