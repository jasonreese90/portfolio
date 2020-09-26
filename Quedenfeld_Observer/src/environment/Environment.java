//Jason Quedenfeld
package environment;

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
    
    /**
    * Create an instance.
    * 
    * @param width the number of rows of cells the environment contains
    * @param height the number of columns of cells the environment contains
    */
    public Environment(int width, int height)
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
}
