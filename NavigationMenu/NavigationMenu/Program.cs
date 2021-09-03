using System;

namespace NavigationMenu
{
	class Program
	{
		public static void Main()
		{
			var lines = MenuService.GetCsvFileData();
			var rootNodes = MenuService.CreateMenuTree(lines);

			// print nodes
			if (rootNodes.Count == 0)
			{
				Console.WriteLine("Error there are no roots nodes in the file.");
			}
			else
			{
				foreach (var rootNode in rootNodes)
				{
					MenuService.PrintMenu(rootNode, 1);
				}
			}
			Console.ReadLine();
		}
	}
}
