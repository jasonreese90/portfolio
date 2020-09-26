import java.util.Scanner;


public class CutTheCake
{
	public void run()
	{
		Scanner scanner = new Scanner(System.in);
		
		String input = scanner.nextLine();
		
		String[] split = input.split("\\s+");
		
		while(!(Integer.parseInt(split[0]) == 0 && Integer.parseInt(split[1])== 0 && Integer.parseInt(split[2])== 0 
				&& Integer.parseInt(split[3])== 0))
		{
		
			int r = Integer.parseInt(split[0]);
			int x = Integer.parseInt(split[1]);
			int y = Integer.parseInt(split[2]);
			int n = Integer.parseInt(split[3]);
			
			int count =0;
			
			Line[] lines = new Line[n];
			
			for(int i = 0; i < n;i++)
			{
				String text = scanner.nextLine();
				String[] coords = text.split("\\s+");
				lines[i] = new Line(Integer.parseInt(coords[0]),Integer.parseInt(coords[1]),
						Integer.parseInt(coords[2]),Integer.parseInt(coords[3]));
				
		
			}
			
			for(int i = 0; i < n;i++)
			{
				if(lineIntersectsCircle(lines[i],r,new Point(x,y)))
					count++;
				
				for(int c = 0; c < n;c++)
				{
					if(c!= i)
					{
						if(pointIsInCircle(getLinesIntersectionPoint(lines[i],lines[c]),r,new Point(x,y)))
							count++;
					}
				}
			}
			
			System.out.println(count+1);
			
			input = scanner.nextLine();
			split = input.split("\\s+");
		}
		
	    scanner.nextLine();
		
		scanner.close();
	}

	public boolean pointIsInCircle(Point p, int r, Point center)
	{
		int x = p.x - center.x;
		int y = p.y - center.y;
		
		return (x*x)+(y*y) < (r*r);
	}
	
	public Point getLinesIntersectionPoint(Line l1, Line l2)
	{
		int a1 = l1.y2 - l1.y1;
		int b1 = l1.x1 - l1.x2;
		int c1 = a1*l1.x1 + b1*l1.y1;
		
		int a2= l2.y2 - l2.y1;
		int b2 = l2.x1 - l2.x2;
		int c2 = a2*l1.x1 + b2*l1.y1;
		
		int delta = a1*b2-a2*b1;
		//lines don't intersect	
		if(delta==0)
			return null;
		
		int x = (b2*c1-b1*c2)/delta;
		int y = (a1*c2-a2*c1)/delta;
		return new Point(x,y);
	}

	public boolean lineIntersectsCircle(Line l, int r, Point center)
	{
		int x = l.xDifference() - center.x;
		int y = l.yDifference() - center.y;
		
		int dr = (int)Math.sqrt((x*x)+(y*y));
		
		int d = l.x1*l.y2- l.x2*l.y1;

		int discriminant = (r*r)*(dr*dr)-(d*d);
		
		
		return discriminant > 0;
		
	}
	
	public class Point
	{
		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		
		public int x, y;
	}

	public class Line
	{
		public Line(int x1, int y1, int x2, int y2)
		{
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
			
			p1 = new Point(x1,y1);
			p2 = new Point(x2,y2);
		}
		
		public int x1,y1, x2, y2;
		public Point p1, p2;
		
		public int xDifference()
		{
			return x2-x1;
		}
		
		public int xDifferenceSquared()
		{
			return (xDifference()*xDifference());
		}
		
		
		public int yDifferenceSquared()
		{
			return (yDifference()*yDifference());
		}
		
		public int yDifference()
		{
			return y2-y1;
		}
		
		public int slope()
		{
			return 0;
		}
	}
}
