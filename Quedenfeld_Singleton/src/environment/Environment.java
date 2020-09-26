//Jason Quedenfeld
package environment;

import weapon.Weapon;
import lifeform.*;

/**
 * An Environment that can hold a two-dimensional array of Cells.
 * 
 *
 */
public class Environment
{
    private Cell[][] cells;
    
    private int width, height;
    
    private static Environment theWorld = new Environment(2,3);
    
    /**
    * Create an instance.
    * 
    * @param width the number of rows of cells the environment contains
    * @param height the number of columns of cells the environment contains
    */
    private Environment(int width, int height)
    {
        cells = new Cell[width][height];
        
        this.width = width;
        this.height = height;
        
        for(int x = 0; x < width;x++)
        {
            for(int y =0; y < height;y++)
            {
                cells[x][y] = new Cell();
            }
        }
    }
    
    /**
     * 
     * @return returns the singleton instance of the Environment
     */
    public static Environment getWorldInstance()
    {
    	return theWorld;
    }
    
    /**
     * For testing purposes only
     * @param width the number of rows of cells the environment contains
     * @param height the number of columns of cells the environment contains
     * @return an instance of Environment
     */
    protected static Environment createEnvironment(int width, int height)
    {
    	return new Environment(width,height);
    }
    
    
    /**
     * gets the distance between two lifeforms
     * @param lifeForm1 first lifeform
     * @param lifeForm2 second lifeform
     * @return returns the distance computed
     */
    public int getDistance(LifeForm lifeForm1, LifeForm lifeForm2)
    {
    	OrderedPair pos1 = getLifeFormPosition(lifeForm1);
      	OrderedPair pos2 = getLifeFormPosition(lifeForm2);
      	
      	int x = pos2.x - pos1.x;
      	int y = pos2.y - pos1.y;
      	
    	return (int)(Math.sqrt(Math.abs((double)(x*x)+(y*y))) * 10);
    }
    
    
    /**
     * returns the position the lifeform located in the cells.
     * @param lifeForm the lifeform to use.
     * @return returns an x and y value for position.
     */
    private OrderedPair getLifeFormPosition(LifeForm lifeForm)
    {
    	for(int x = 0; x < width; x++)
    	{
    		for(int y = 0; y < height;y++)
    		{
    			if(cells[x][y].getLifeForm() == lifeForm)
    			{
    				return new OrderedPair(x,y);
    			}
    		}
    	}
    	
    	return null;
    }
    
    /**
     * Nested class used for internal computation only.
     *
     *
     */
    private class OrderedPair
    {
    	public OrderedPair(int x, int y)
    	{
    		this.x = x;
    		this.y = y;
    	}
    	
    	int x;
    	int y;
    }
    
    /**
     * Adds a weapon to a cell.
     * @param x the x position of the cell.
     * @param y the y position of the cell.
     * @param weaponSlot the weapon slot in the cell to add the weapon to.
     * @param weapon the weapon to add to the cell.
     */
    public void addWeapon(int x, int y, int weaponSlot, Weapon weapon)
    {
        if(x <  width || y < height)
        {
            cells[x][y].addWeapon(weaponSlot, weapon);
        }
    }
    
    /**
     * Removes a weapon from a cell.
     * @param x the x position of the cell.
     * @param y the y position of the cell.
     * @param weaponSlot the weapon slot in the cell to remove the weapon from.
     * @return returns the removed weapon.
     */
    public Weapon removeWeapon(int x, int y, int weaponSlot)
    {
        if(x <  width || y < height)
        {
            return cells[x][y].removeWeapon(weaponSlot);
        }
        
        return null;
    }
    
    /**
     * 
     * @param x the x position of the cell.
     * @param y the y position of the cell.
     * @param weaponSlot the weapon slot to retrieve the weapon from.
     * @return
     */
    public Weapon getWeapon(int x, int y, int weaponSlot)
    {
        if(x <  width || y < height)
        {
            return cells[x][y].getWeapon(weaponSlot);
        }
        
        return null;
    }
    
    /**
     * Tries to add the LifeForm to the Cell at the given position. Will not add if 
     * LifeForm is already present.
     * 
     * @param row the row the cell is located in.
     * @param col the column the cell is located in.
     * @param entity the LifeForm to be added at the given position.
     * @return true if LifeForm was added to the Cell, false otherwise.
     */
    public boolean addLifeForm(int row, int col, LifeForm entity)
    {
        if(row >= width || col >= height)
        {
            return false;
        }
        
        return cells[row][col].addLifeForm(entity);
    }
    
    /**
     * Returns a LifeForm at the given position.
     * 
     * @param row the row the cell is located in.
     * @param col the column the cell is located in.
     * @return the LifeForm at the given position.
     */
    public LifeForm getLifeForm(int row, int col)
    {
        if(row >= width || col >= height)
        {
            return null;
        }
        
        return cells[row][col].getLifeForm();
    }
    
    /**
     * Tries to removed a LifeForm at the given position, if one exists.
     * 
     * @param row the row the cell is located in.
     * @param col the column the cell is located in.
     * @return the LifeForm removed at the given position.
     */
    public LifeForm removeLifeForm(int row, int col)
    {
        if(row >= width || col >= height)
        {
            return null;
        }
        
        return cells[row][col].removeLifeForm();
    }
    
    /**
     * Returns whether a Cell exists ate the given position.
     * 
     * @param row the row the cell is located in.
     * @param col the column the cell is located in.
     * @return true if the Cell exists at the given position, false otherwise.
     */
    public boolean cellExists(int row, int col)
    {
        if(row >= width || col >= height)
        {
            return false;
        }
        
        return cells[row][col] != null;
    }
    
    
    /**
     * populates the cells with new life forms.
     */
    public void clear()
    {
    	 for(int x = 0; x < width;x++)
         {
             for(int y =0; y < height;y++)
             {
                 cells[x][y] = new Cell();
             }
         }
    }
}
