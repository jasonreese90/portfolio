//Jason Quedenfeld
package environment;

import lifeform.*;

/**
 * A Cell that can hold a LifeForm
 *
 */
public class Cell
{
    private LifeForm entity;
    
    /**
     * @return the LifeForm in this Cell.
     */
    public LifeForm getLifeForm()
    {
        return entity;
    }
    
    /**
     * Tries to add the LifeForm to the Cell. Will not add if 
     * LifeForm is already present.
     * @return true if LifeForm was added to the Cell, false otherwise.
     */
    public boolean addLifeForm(LifeForm entity)
    {
        if(this.entity == null)
        {
            this.entity = entity;
            return true;
        }
        
        return false;
    }
    
    /**
     * Removes an existing LifeForm from the cell.
     * @return  returns a LifeForm if ones is present, otherwise returns null.
     */
    public LifeForm removeLifeForm()
    {
        LifeForm temp = entity;
        entity = null;
        
        return temp;
    }
}
