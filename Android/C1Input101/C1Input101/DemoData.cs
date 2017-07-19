using System;
using System.Collections.Generic;
using System.Text;

namespace C1Input101
{
	public class Countries : object
	{
		
		public string Name { get; set; }

		public Countries()
		{
			this.Name = string.Empty;
		}

		public Countries(string name, double sales, double salesgoal, double download, double downloadgoal, double expense, double expensegoal, string fruits)
		{
			this.Name = name;
		}

		public static IEnumerable<object> GetDemoDataList()
		{
			List<object> array = new List<object>();

			//NSMutableArray array = new NSMutableArray();
			var quarterNames = "Australia,Bangladesh,Brazil,Canada,China".Split(',');

			for (int i = 0; i < quarterNames.Length; i++)
			{
				array.Add(new Countries
					{
						Name = quarterNames[i]
					});
			}
			return array as IEnumerable<object>;
		}
	}

	public class Countries1 : object
	{

		public string Name { get; set; }
		public int ImageId { get; set; }

		public Countries1()
		{
			this.Name = string.Empty;
		}

		public Countries1(string name,int imageId, double sales, double salesgoal, double download, double downloadgoal, double expense, double expensegoal, string fruits)
		{
			this.Name = name;
			this.ImageId = imageId;
		}

		public static IEnumerable<object> GetDemoDataList()
		{
			List<object> array = new List<object>();

			//NSMutableArray array = new NSMutableArray();
			var quarterNames = "Australia,Bangladesh,Brazil,Canada,China".Split(',');
			var ImageIds = new int[] {Resource.Drawable.australia,Resource.Drawable.bangladesh,Resource.Drawable.brazil,Resource.Drawable.canada,Resource.Drawable.china };

			for (int i = 0; i < quarterNames.Length; i++)
			{
				array.Add(new Countries1
				{
					Name = quarterNames[i],
					ImageId = ImageIds[i]

				});
			}
			return array as IEnumerable<object>;
		}
	}
}
