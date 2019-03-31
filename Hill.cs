using System.Drawing;

namespace Elevation
{
	public struct Hill
	{
		public string Name { get; set; }

		public Point Peak { get; set; }

		public double Height { get; set; }

		public double Slope { get; set; }
	}
}