using System;
using System.Drawing;

namespace Elevation
{
	class Program
	{
		private static double GetHeightAtPosition(Hill[] hills, int x, int y)
		{
			var totalHeight = 0.0;

			foreach (var hill in hills)
			{
				var slopeCoefficient = -(hill.Slope * hill.Slope);
				var diffX = x - hill.Peak.X;
				var diffY = y - hill.Peak.Y;
				var innerSegment = diffX * diffX + diffY * diffY;

				totalHeight += Math.Exp(slopeCoefficient * innerSegment) * hill.Height;
			}
			
			return totalHeight;
		}
		
		static void Main(string[] args)
		{
			var hills = new[]
			{
				new Hill
				{
					Name = "Ada's Apex",
					Peak = new Point(12, 9),
					Height = 20.0,
					Slope = 0.25
				},
				new Hill
				{
					Name = "Turing's Top",
					Peak = new Point(4, 3),
					Height = 20.0,
					Slope = 0.33
				},
				new Hill
				{
					Name = "Babbage's Bluff",
					Peak = new Point(6, 13),
					Height = 15.0,
					Slope = 0.33
				},
				new Hill
				{
					Name = "Hopper's Hill",
					Peak = new Point(14, 2),
					Height = 15.0,
					Slope = 0.5
				},
				new Hill
				{
					Name = "Katherine's Cliff",
					Peak = new Point(1, 9),
					Height = 10.0,
					Slope = 0.5
				}
			};

			const int mapSizeX = 19;
			const int mapSizeY = 15;

			for (var y = 0; y < mapSizeY; y++)
			{
				for (var x = 0; x < mapSizeX; x++)
				{
					if (x == 0 || x == mapSizeX - 1 || y == 0 || y == mapSizeY - 1)
					{
						Console.Write("00.00 ");
					}
					else
					{

						var height = GetHeightAtPosition(hills, x, y);

						Console.Write($"{height:00.00} ");
					}
				}
				Console.Write("\n");
			}
			
			Console.WriteLine(GetHeightAtPosition(hills, 12, 9));
		}
	}
}