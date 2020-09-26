package ui;

import static org.junit.Assert.*;

import org.junit.Test;

import weapon.ChainGun;
import weapon.Pistol;
import weapon.PlasmaCannon;

import javax.swing.*;

import lifeform.Alien;
import lifeform.Human;
import environment.Environment;

/**
 * Test cases for the MapLegendGUI class
 * @author Matthew Hoffman
 *
 */

public class TestMapLegendGUI 
{
	/**
	 * Tests that both the Map and Legend GUI are fully functional.
	 * For reference, the layout for information about each cell in the Environment is as follows:
	 * Direction, LifeForm, LifePoints
	 * Weapon, Attachments, Ammo
	 * CellWeapon1, CellWeapon2, Blank Space
	 * Legend follows this pattern:
	 * Image or text, description for the image or text
	 * 
	 * If any part of the cell has an N/A, that means functionality for displaying that info is not
	 * yet fully implemented.
	 */
	@SuppressWarnings("unused")
	@Test
	public void testUserInterfaceMapAndLegend() 
	{
		Environment worldInstance = Environment.createEnvironment(4, 4);
		Human human1 = new Human("Joe", 40, 0);
		Alien alien1 = new Alien("Predator", 50);
		Pistol pistol1 = new Pistol(0,0,0,0,0);
		Pistol pistol2 = new Pistol(0,0,0,0,0);
		Pistol pistol3 = new Pistol(0,0,0,0,0);
		PlasmaCannon plasma1 = new PlasmaCannon(0,0,0,0,0);
		PlasmaCannon plasma2 = new PlasmaCannon(0,0,0,0,0);
		ChainGun chain1 = new ChainGun(0,0,0,0,0);
		ChainGun chain2 = new ChainGun(0,0,0,0,0);
		ChainGun chain3 = new ChainGun(0,0,0,0,0);
		human1.pickUpWeapon(pistol1);
		alien1.pickUpWeapon(plasma1);
		worldInstance.addLifeForm(0, 0, human1);
		worldInstance.addWeapon(0,0,1,plasma2);
		worldInstance.addWeapon(0,0,2,chain1);
		worldInstance.addLifeForm(0, 1, alien1);
		worldInstance.addWeapon(0,1,1,pistol2);
		worldInstance.addWeapon(0,1,2,chain2);
		Human human2 = new Human("Bob", 30, 0);
		Alien alien2 = new Alien("Alien", 70);
		worldInstance.addLifeForm(0, 2, human2);
		worldInstance.addLifeForm(0, 3, alien2);
		Human human3 = new Human("Mike", 45, 0);
		ChainGun chain4 = new ChainGun(0,0,0,0,0);
		human3.pickUpWeapon(chain4);
		worldInstance.addLifeForm(1,0,human3);
		worldInstance.addWeapon(1,0,1,chain3);
		worldInstance.addWeapon(1,0,2,pistol3);

		MapLegendGUI map = new MapLegendGUI(worldInstance);
		assertEquals(JOptionPane.YES_OPTION, JOptionPane.showConfirmDialog(null, "Does the map and legend look right?"));
	}

}
