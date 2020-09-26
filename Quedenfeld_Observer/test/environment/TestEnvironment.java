//Jason Quedenfeld
package environment;

import static org.junit.Assert.*;
import org.junit.Test;

import lifeform.*;

/**
 * Tests the functionality provided by the Environment class
 * 
 */
public class TestEnvironment
{
    /**
     * Creates an Environment that consists of rows and columns of cells.
     */
    @Test
    public void testInitialization()
    {
        Environment env;
        env = new Environment(1,1); 
        
        assertTrue(env.cellExists(0, 0));
        assertNull(env.getLifeForm(0, 0));
  
        env = new Environment(2,3); 
        
        LifeForm entity;
        entity = new MockLifeForm("Bob",40);
        
        env.addLifeForm(1, 2, entity);
        assertNotNull(env.getLifeForm(1, 2));
    }
    
    /**
     * Tests the remove functionality of the environment
     */
    @Test
    public void testRemoveLifeForm()
    {
        Environment env;
        env = new Environment(2,3); 
        
        LifeForm entity;
        entity = new MockLifeForm("Bob",40);
        
        env.addLifeForm(1, 2, entity);
        assertNotNull(env.getLifeForm(1, 2));
        
        env.removeLifeForm(1, 2);
        entity = env.getLifeForm(1, 2);
        
        assertNull(entity);
    }
    
    /**
     * Tests the array boundaries using the addLifeForm, getLifeForm, removeLifeForm methods
     */
    @Test
    public void testBoundaries()
    {
        Environment env;
        env = new Environment(2,3); 
        
        LifeForm entity;
        entity = new MockLifeForm("Bob",40);
        
        assertFalse(env.addLifeForm(2, 3, entity));
        
        assertNull(env.getLifeForm(2, 3));
        
        assertNull(env.removeLifeForm(2,3));
    }
}
