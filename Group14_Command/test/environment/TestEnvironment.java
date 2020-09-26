//Jason Quedenfeld
package environment;

import static org.junit.Assert.*;

import org.junit.Test;

import weapon.PlasmaCannon;
import weapon.Weapon;
import lifeform.*;

/**
 * Tests the functionality provided by the Environment class
 * 
 */
public class TestEnvironment
{
	/**
	 * Tests that a human can move north.
	 */
	@Test
	public void testMoveHumanNorthWithoutObstacle()
	{
	    Environment env = Environment.createEnvironment(10,10); 
		Human human = new Human("Bob",40,1);
		
		env.addLifeForm(0,9,human);
		
		env.moveLifeForm(human,2);
		
		assertEquals(env.getLifeForm(0,9),null);
		assertEquals(env.getLifeForm(0,7),human);
	}
	
	/**
	 * Tests that a human can move north, when another human is in the way.
	 */
	@Test
	public void testMoveHumanNorthWithObstacle()
	{
		Environment env = Environment.createEnvironment(10,10); 
		Human human = new Human("Bob",40,1);
		Human human2 = new Human("boB",40,1);
		
		env.addLifeForm(0,9,human);
		env.addLifeForm(0, 8, human2);
		
		env.moveLifeForm(human,2);
		
		assertEquals(env.getLifeForm(0,9),null);
		assertEquals(env.getLifeForm(0,7),human);
	}
	
	/**
	 * Tests that a human doesn't move north if already is at max.
	 */
	@Test
	public void testHumanDoesNotExceedNorthBounds()
	{
	    Environment env = Environment.createEnvironment(10,10); 
		Human human = new Human("Bob",40,1);
		
		env.addLifeForm(0,0,human);
		
		assertFalse(env.moveLifeForm(human,2));
	}
	
	/**
	 * Tests that a human can move south.
	 */
	@Test
	public void testMoveHumanSouthWithoutObstacle()
	{
	    Environment env = Environment.createEnvironment(10,10); 
		Human human = new Human("Bob",40,1);
		human.changeDirection(Human.DIRECTION_SOUTH);
		env.addLifeForm(0,7,human);
		
		env.moveLifeForm(human,2);
		
		assertEquals(env.getLifeForm(0,7),null);
		assertEquals(env.getLifeForm(0,9),human);
	}
	
	/**
	 * Tests that a human can move south, when another human is in the way.
	 */
	@Test
	public void testMoveHumanSouthWithObstacle()
	{
		Environment env = Environment.createEnvironment(10,10); 
		Human human = new Human("Bob",40,1);
		Human human2 = new Human("boB",40,1);
		
		human.changeDirection(Human.DIRECTION_SOUTH);
		
		env.addLifeForm(0, 7,human);
		env.addLifeForm(0, 8, human2);
		
		env.moveLifeForm(human,2);
		
		assertEquals(env.getLifeForm(0,7),null);
		assertEquals(env.getLifeForm(0,9),human);
	}
	
	/**
	 * Tests that a human doesn't move south if already is at max.
	 */
	@Test
	public void testHumanDoesNotExceedSouthBounds()
	{
	    Environment env = Environment.createEnvironment(10,10); 
		Human human = new Human("Bob",40,1);
		human.changeDirection(Human.DIRECTION_SOUTH);
		env.addLifeForm(0,9,human);
		
		assertFalse(env.moveLifeForm(human,2));
	}
	
	/**
	 * Tests that an alien can move east.
	 */
	@Test
	public void testMoveAlienEastWithoutObstacle()
	{
	    Environment env = Environment.createEnvironment(10,10); 
		Alien alien = new Alien("Bob",40);
		alien.changeDirection(Alien.DIRECTION_EAST);
		env.addLifeForm(0,9,alien);
		
		env.moveLifeForm(alien,2);
		
		assertEquals(env.getLifeForm(0,9),null);
		assertEquals(env.getLifeForm(2,9),alien);
	}
	
	/**
	 * Tests that an alien can move east, when another alien is in the way.
	 */
	@Test
	public void testMoveAlienEastWithObstacle()
	{
	    Environment env = Environment.createEnvironment(10,10); 
		Alien alien = new Alien("Bob",40);
		Alien alien2 = new Alien("Bob",40);
		alien.changeDirection(Alien.DIRECTION_EAST);
		env.addLifeForm(0,9,alien);
		env.addLifeForm(1,9,alien2);
		
		env.moveLifeForm(alien,2);
		
		assertEquals(env.getLifeForm(0,9),null);
		assertEquals(env.getLifeForm(2,9),alien);
	}
	
	/**
	 * Tests that an alien doesn't move east if already is at max.
	 */
	@Test
	public void testAlienDoesNotExceedEastBounds()
	{
	    Environment env = Environment.createEnvironment(10,10); 
		Alien alien = new Alien("Bob",40);
		alien.changeDirection(Alien.DIRECTION_EAST);
		env.addLifeForm(9,0,alien);
		
		assertFalse(env.moveLifeForm(alien,2));
	}
	
	/**
	 * Tests that an alien can move west.
	 */
	@Test
	public void testMoveAlienWestWithoutObstacle()
	{
	    Environment env = Environment.createEnvironment(10,10); 
		Alien alien = new Alien("Bob",40);
		alien.changeDirection(Alien.DIRECTION_WEST);
		env.addLifeForm(2,9,alien);
		
		env.moveLifeForm(alien,2);
		
		assertEquals(env.getLifeForm(2,9),null);
		assertEquals(env.getLifeForm(0,9),alien);
	}
	
	/**
	 * Tests that an alien can move west, when another alien is in the way.
	 */
	@Test
	public void testMoveAlienWestWithObstacle()
	{
	    Environment env = Environment.createEnvironment(10,10); 
		Alien alien = new Alien("Bob",40);
		Alien alien2 = new Alien("Bob",40);
		alien.changeDirection(Alien.DIRECTION_WEST);
		env.addLifeForm(2,9,alien);
		env.addLifeForm(1,9,alien2);
		
		env.moveLifeForm(alien,2);
		
		assertEquals(env.getLifeForm(2,9),null);
		assertEquals(env.getLifeForm(0,9),alien);
	}
	
	/**
	 * Tests that an alien doesn't move west if already is at max.
	 */
	@Test
	public void testAlienDoesNotExceedWestBounds()
	{
	    Environment env = Environment.createEnvironment(10,10); 
		Alien alien = new Alien("Bob",40);
		alien.changeDirection(Alien.DIRECTION_WEST);
		env.addLifeForm(0,0,alien);
		
		assertFalse(env.moveLifeForm(alien,2));
	}
	
	
	/**
	 * Start Section for Singleton Pattern Tests
	 */
	
	/**
	 * Tests that a weapon can be added to a specific cell.
	 */
    @Test
    public void testAddWeapon()
    {
        Environment env = Environment.createEnvironment(2,3); 
    	PlasmaCannon cannon = new PlasmaCannon(4,50,40,1,2);
    	env.addWeapon(0,1,0, cannon);
    	
    	assertEquals(cannon,env.getWeapon(0, 1, 0));
    }
    
	/**
	 * Tests that a weapon can be removed from a specific cell.
	 */
    @Test
    public void testRemoveWeapon()
    {
        Environment env = Environment.createEnvironment(2,3); 
    	PlasmaCannon cannon = new PlasmaCannon(4,50,40,1,2);
      	env.addWeapon(0,1,0, cannon);
    	
    	
    	Weapon weapon = env.removeWeapon(0, 1, 0);
    	
    	assertNull(env.getWeapon(0, 1, 0));
    	assertEquals(cannon,weapon);
    }
    
	/**
	 * tests that distance is calculated correctly on the same row.
	 */
    @Test
    public void testLifeFormDistanceSameRow()
    {
        Environment env = Environment.createEnvironment(2,3); 
        
        LifeForm entity = new MockLifeForm("Bob",40);
        LifeForm entity2 = new MockLifeForm("Bob",40);

        env.addLifeForm(1, 2, entity);
        env.addLifeForm(0, 2, entity2);
        assertEquals(env.getDistance(entity, entity2),10);
    }
    
	/**
	 * tests that distance is calculated correctly on the same column.
	 */
    @Test
    public void testLifeFormDistanceSameColumn()
    {
        Environment env = Environment.createEnvironment(2,3); 
        
        LifeForm entity = new MockLifeForm("Bob",40);
        LifeForm entity2 = new MockLifeForm("Bob",40);

        env.addLifeForm(1, 0, entity);
        env.addLifeForm(1, 2, entity2);
        
        assertEquals(env.getDistance(entity, entity2),20);
    }
    
    
	/**
	 * tests that distance is calculated correctly when not on the same row or column.
	 */
    @Test
    public void testLifeFormDistanceNotSameRowColumn()
    {
        Environment env = Environment.createEnvironment(2,3); 
        
        LifeForm entity = new MockLifeForm("Bob",40);
        LifeForm entity2 = new MockLifeForm("Bob",40);

        env.addLifeForm(0, 1, entity);
        env.addLifeForm(1, 2, entity2);
        
        assertEquals(env.getDistance(entity, entity2),14);
    }
    
    
	/**
	 * tests that a life form can be added to the environment.
	 */
    @Test
    public void testAddLifeForm()
    {
    	 Environment env = Environment.createEnvironment(2,3); 
         
         LifeForm entity;
         entity = new MockLifeForm("Bob",40);
         
         env.addLifeForm(1, 2, entity);
         assertNotNull(env.getLifeForm(1, 2));
    }
    
    
	
	
	/**
	 * Start Section for Observer Pattern Tests
	 */
	
	
    /**
     * Creates an Environment that consists of rows and columns of cells.
     */
    @Test
    public void testInitialization()
    {
        Environment env;
        env = Environment.createEnvironment(1,1); 
        
        assertTrue(env.cellExists(0, 0));
        assertNull(env.getLifeForm(0, 0));
    }
    
    /**
     * Tests the remove functionality of the environment
     */
    @Test
    public void testRemoveLifeForm()
    {
        Environment env;
        env = Environment.createEnvironment(2,3); 
        
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
        env = Environment.createEnvironment(2,3); 
        
        LifeForm entity;
        entity = new MockLifeForm("Bob",40);
        
        assertFalse(env.addLifeForm(2, 3, entity));
        
        assertNull(env.getLifeForm(2, 3));
        
        assertNull(env.removeLifeForm(2,3));
    }
}
