﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Enterprise_communication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.departmentTree.ItemsSource = GetTrees(0, GetNodes());//数据绑定
        }

        public List<NodeModel> GetNodes()
        {
            List<NodeModel> dplst = new List<NodeModel>(){
            new NodeModel(){Id=1,Name="人事部",ParentId=0,Avatar=string.Empty,State=string.Empty,Visibility="Collapsed"},
            new NodeModel(){Id=2,Name="开发部",ParentId=0,Avatar=string.Empty,State=string.Empty,Visibility="Collapsed"},
            new NodeModel(){Id=3,Name="小李",ParentId=1,Avatar="images\\214743981.jpg",State="在线", Visibility="Visible"},
            new NodeModel(){Id=4,Name="小王",ParentId=2,Avatar="images\\214743981.jpg",State="离线", Visibility="Visible"},
            };
            return dplst;
        }

        /// <summary>
        /// 递归生成树形数据
        /// </summary>
        /// <param name="delst"></param>
        /// <returns></returns>
        public List<NodeModel> GetTrees(int parentid, List<NodeModel> nodes)
        {
            List<NodeModel> mainNodes = nodes.Where(x => x.ParentId == parentid).ToList<NodeModel>();
            List<NodeModel> otherNodes = nodes.Where(x => x.ParentId != parentid).ToList<NodeModel>();
            foreach (NodeModel dpt in mainNodes)
            {
                dpt.Nodes = GetTrees(dpt.Id, otherNodes);
            }
            return mainNodes;
        }
    }
    public class NodeModel
    {
        public List<NodeModel> Nodes { get; set; }
        public NodeModel()
        {
            this.Nodes = new List<NodeModel>();
            this.ParentId = 0;//主节点的父id默认为0
        }
        public int Id { get; set; }//id
        public string Name { get; set; }//部门名称
        public int ParentId { get; set; }//父类id
        public string Avatar { get; set; }
        public string State { get; set; }
        public string Visibility { get; set; } = "Visible";
    }
    
}
