//Jason Quedenfeld
package lifeform;

import static org.junit.Assert.*;
import org.junit.Test;

/**
 * Tests the functionality provided by the LifeForm class
 * 
 */
public class TestLifeForm
{
    /**
     * When a LifeForm is created, it should know its name and how
     * many life points it has.
     */
    @Test
    public void testInitialization()
    {
        LifeForm entity;
        entity = new MockLifeForm("Bob",40);
        assertEquals("Bob",entity.getName());
        assertEquals(40,entity.getCurrentLifePoints());
        
        //Life points shouldn't fall below 0
        
        entity = new MockLifeForm("Bob",-40);
        
        assertTrue(entity.getCurrentLifePoints() >= 0);
    }
    
    /**
     *  Tests that life points cannot fall below 0.
     */
    @Test
    public void testTakeHit()
    {
    	LifeForm entity = new MockLifeForm("Bob",40);
    	
    	assertTrue(entity.getCurrentLifePoints() >= 0);
    	entity.takeHit(50);
      	assertTrue(entity.getCurrentLifePoints() >= 0); 
    }
}
