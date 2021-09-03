using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NavigationMenu
{
   public class MenuService
    {
		public static string[] GetCsvFileData()
		{
			string pathFile = @"C:\Users\dukos\Desktop\Task1\NavigationMenu\NavigationMenu\csvFile\Navigation - Test1.csv";

			var csvLines = File.ReadAllLines(pathFile);

			return csvLines;
		}
		public static MenuNode CreateMenuNode(string[] columns)
		{
			var id = Convert.ToInt32(columns[0]);
			var menuName = columns[1];
			var parentID = ToInt(columns[2]);
			var isHidden = Convert.ToBoolean(columns[3]);
			var linkURL = columns[4];

			var item = new MenuItem()
			{
				ID = id,
				MenuName = menuName,
				ParentID = parentID,
				IsHidden = isHidden,
				LinkUrl = linkURL
			};
			return new MenuNode()
			{
				ItemData = item
			};
		}

		public static List<MenuNode> CreateMenuTree(string[] lines)
		{
			var rootFound = false;
			var nodes = new List<MenuNode>();
			var dict = new Dictionary<int, List<MenuNode>>();

			foreach (var row in lines.Skip(1))
			{
				var node = CreateMenuNode(row.Split(';'));
				nodes.Add(node);

				if (node.ItemData.ParentID == -1)
				{
					//Console.WriteLine("Found root:" + node.ItemData.ID + " - " + node.ItemData.MenuName);
					rootFound = true;
				}
				if (!dict.ContainsKey(node.ItemData.ParentID))
				{
					dict.Add(node.ItemData.ParentID, new List<MenuNode>());
				}
				dict[node.ItemData.ParentID].Add(node);
			}

			foreach (MenuNode node in nodes)
			{
				if (dict.ContainsKey(node.ItemData.ID))
				{
					node.Children = dict[node.ItemData.ID];
				}
			}
			return rootFound ? dict[-1] : new List<MenuNode>();
		}

		public static void PrintMenu(MenuNode node, int dots)
		{
			if (node.ItemData.IsHidden) return;
			for (var i = 0; i < dots; i++)
			{
				Console.Write(".");
			}
			Console.WriteLine(node.ItemData.MenuName);
			if (node.Children.Count() > 0)
			{
				IEnumerable<MenuNode> temp = node.Children.OrderBy(b => b.ItemData.MenuName);
				foreach (var childNode in temp)
				{
					PrintMenu(childNode, dots + 3);
				}
			}
		}

		//if the string is not int will return -1
		public static int ToInt(string s)
		{
			int i;
			if (int.TryParse(s, out i)) return i;
			return -1;
		}
	}
}
