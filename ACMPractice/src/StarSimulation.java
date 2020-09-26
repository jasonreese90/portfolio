import java.util.ArrayList;
import java.util.Comparator;
import java.util.Scanner;

public class StarSimulation 
{
	
	public void run()
	{
		Scanner scanner = new Scanner(System.in);
		
		String input = scanner.nextLine();
		
		String[] split = input.split("\\s+");
		
		while(Integer.parseInt(split[0]) != 0 && Integer.parseInt(split[1])!= 0)
		{
			int n = Integer.parseInt(split[0]);
			int k = Integer.parseInt(split[1]);
			int count = 0;
			
			ArrayList<Point> points = new ArrayList<Point>();
			ArrayList<Point> p = new ArrayList<Point>();
			
			for(int i = 0; i < n;i++)
			{
				String text = scanner.nextLine();
				String[] coords = text.split("\\s+");
				int x = Integer.parseInt(coords[0]);
				int y = Integer.parseInt(coords[1]);
				int z = Integer.parseInt(coords[2]);
				points.add(new Point(x,y,z));
				
			}
			
			points.sort(new Comparator<Point>() {

				@Override
				public int compare(Point arg0, Point arg1) 
				{
					int dis = distance(arg0,arg1);
					
					p.add(arg0);
					
					if(dis >= k)
						return 1;
					else
						return -1;
				}
			});
			
			
			System.out.println(p.size());
			input = scanner.nextLine();
			split = input.split("\\s+");
		}
		
	
		scanner.close();
	}
	
	public int distance(Point p1, Point p2)
	{
		int x = p2.x-p1.x;
		int y = p2.y-p1.y;
		int z = p2.z- p1.z;
		
		return (int)Math.sqrt((x*x)+(y*y)+(z*z));
	}
	
	public class Point
	{
		public Point(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		
		public int x,y,z;
	}

}
