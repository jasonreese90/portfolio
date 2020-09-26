package ui;

import java.awt.*;

import javax.swing.*;

import lifeform.Alien;
import lifeform.Human;
import weapon.ChainGun;
import weapon.Pistol;
import weapon.PlasmaCannon;
import environment.Environment;

/**
 * Class responsible for creating the Map and Legend GUI.
 * Will add update functionality at a later date.
 * Will also add the following information later:
 * LifePoints
 * Attachments
 * Ammo
 * @author Matthew Hoffman
 *
 */
@SuppressWarnings("serial")
public class MapLegendGUI extends JFrame
{
	private JFrame frame;
	private JPanel mainPanel;
	private JPanel westPanel;
	private JPanel eastPanel;
	private JPanel[] sector;
	private int rows, columns, area;
	
	/**
	 * Map and legend GUI constructor.
	 * Receives a copy of the singleton worldInstance, and
	 * uses that to pick the relevant data to fill out the GUI.
	 * @param rows
	 * @param columns
	 */
	public MapLegendGUI(Environment worldInstance)
	{
		rows = worldInstance.getRows();
		columns = worldInstance.getColumns();
		area = (rows * columns);
		frame = new JFrame();
		mainPanel = new JPanel(new GridLayout(1, 2));
		westPanel = new JPanel(new GridLayout(rows, columns));
		eastPanel = new JPanel(new GridLayout(10, 2));
		sector = new JPanel[area];
		
		//Initializes enough JPanels to simulate the environment.
		for(int i = 0; i < area; i++)
		{
			sector[i] = new JPanel(new GridLayout(3, 3));
		}
		
		//Map Section
		int count = 0;
		for(int i = 0; i < rows; i++)
		{
			for(int j = 0; j < columns; j++)
			{
				//Various TextPanes used to display environment data
				JTextPane direction = new JTextPane();
				JTextPane lifeform = new JTextPane();
				JTextPane lifepoints = new JTextPane();
				JTextPane weapon = new JTextPane();
				JTextPane attachment = new JTextPane();
				JTextPane ammo = new JTextPane();
				JTextPane cellWep1 = new JTextPane();
				JTextPane cellWep2 = new JTextPane();
				
				//Data pertaining to LifeForms
				if(worldInstance.getLifeForm(i, j) != null)
				{
					direction.setText(worldInstance.getLifeForm(i, j).getCurrentDirection());
					
					if(worldInstance.getLifeForm(i, j) instanceof Human)
					{
						lifeform.setText("Human");
					}
					
					else if(worldInstance.getLifeForm(i, j) instanceof Alien)
					{
						lifeform.setText("Alien");
					}
					
					else
					{
						lifeform.setText("Mock");
					}
					
					lifepoints.setText("N/A");
					
					if(worldInstance.getLifeForm(i, j).getCurrentWeapon() != null)
					{
						if(worldInstance.getLifeForm(i, j).getCurrentWeapon() instanceof Pistol)
						{
							weapon.setText("Pistol");
							attachment.setText("N/A");
							ammo.setText("N/A");
						}
						
						else if(worldInstance.getLifeForm(i, j).getCurrentWeapon() instanceof PlasmaCannon)
						{
							weapon.setText("Plasma Cannon");
							attachment.setText("N/A");
							ammo.setText("N/A");
						}
						
						else if(worldInstance.getLifeForm(i, j).getCurrentWeapon() instanceof ChainGun)
						{
							weapon.setText("Chain Gun");
							attachment.setText("N/A");
							ammo.setText("N/A");
						}
						
						else
						{
							weapon.setText("Generic Weapon");
							attachment.setText("N/A");
							ammo.setText("N/A");
						}
					}
					
					else
					{
						weapon.setText("None");
						attachment.setText("N/A");
						ammo.setText("N/A");
					}
				}
				
				else
				{
					direction.setText("None");
					lifeform.setText("None");
					lifepoints.setText("N/A");
					weapon.setText("None");
					attachment.setText("N/A");
					ammo.setText("N/A");
				}
				
				//Cell weapon slot #1
				if(worldInstance.getWeapon(i, j, 1) != null)
				{
					if(worldInstance.getWeapon(i, j, 1) instanceof Pistol)
					{
						cellWep1.setText("Pistol");
					}
					
					else if(worldInstance.getWeapon(i, j, 1) instanceof PlasmaCannon)
					{
						cellWep1.setText("Plasma Cannon");
					}
					
					else if(worldInstance.getWeapon(i, j, 1) instanceof ChainGun)
					{
						cellWep1.setText("Chain Gun");
					}
					
					else
					{
						cellWep1.setText("Generic Weapon");
					}
				}
				
				else
				{
					cellWep1.setText("None");
				}

				//Cell weapon slot #2
				if(worldInstance.getWeapon(i, j, 2) != null)
				{
					if(worldInstance.getWeapon(i, j, 2) instanceof Pistol)
					{
						cellWep2.setText("Pistol");
					}
					
					else if(worldInstance.getWeapon(i, j, 2) instanceof PlasmaCannon)
					{
						cellWep2.setText("Plasma Cannon");
					}
					
					else if(worldInstance.getWeapon(i, j, 2) instanceof ChainGun)
					{
						cellWep2.setText("Chain Gun");
					}
					
					else
					{
						cellWep2.setText("Generic Weapon");
					}
				}
					
				else
				{
					cellWep2.setText("None");
				}
				
				sector[count].add(direction);
				sector[count].add(lifeform);
				sector[count].add(lifepoints);
				sector[count].add(weapon);
				sector[count].add(attachment);
				sector[count].add(ammo);
				sector[count].add(cellWep1);
				sector[count].add(cellWep2);
				
				westPanel.add(sector[count]);
				count++;
			}
		}
		
		//Legend Section
		
		//Direction
		JTextPane direction = new JTextPane();
		JTextPane directionInfo = new JTextPane();
		direction.setText("North");
		directionInfo.setText("Indicates the LifeForm's facing direction.");
		
		//Human
		JTextPane human = new JTextPane();
		JTextPane humanInfo = new JTextPane();
		human.setText("Human");
		humanInfo.setText("Indicates a human is occupying the cell.");
		
		//Alien
		JTextPane alien = new JTextPane();
		JTextPane alienInfo = new JTextPane();
		alien.setText("Alien");
		alienInfo.setText("Indicates an alien is occupying the cell.");
		
		//Pistol
		JTextPane pistol = new JTextPane();
		JTextPane pistolInfo = new JTextPane();
		pistol.setText("Pistol");
		pistolInfo.setText("Indicates a pistol.");
		
		//Plasma Cannon
		JTextPane plasmacannon = new JTextPane();
		JTextPane plasmacannonInfo = new JTextPane();
		plasmacannon.setText("Plasma");
		plasmacannonInfo.setText("Indicates a plasma cannon.");
		
		//Chain Gun
		JTextPane chaingun = new JTextPane();
		JTextPane chaingunInfo = new JTextPane();
		chaingun.setText("Chain");
		chaingunInfo.setText("Indicates a chain gun.");
		
		//Numbers (Life points or ammo)
		JTextPane numbers = new JTextPane();
		JTextPane numbersInfo = new JTextPane();
		numbers.setText("10");
		numbersInfo.setText("Number of lifepoints or remaining ammo.");
		
		//Stabilizer
		JTextPane stabilizer = new JTextPane();
		JTextPane stabilizerInfo = new JTextPane();
		stabilizer.setText("Stabilizer");
		stabilizerInfo.setText("Indicates a stabilizer attachment.");
		
		//Power Booster
		JTextPane powerbooster = new JTextPane();
		JTextPane powerboosterInfo = new JTextPane();
		powerbooster.setText("Power");
		powerboosterInfo.setText("Indicates a power booster attachment.");
		
		//Scope
		JTextPane scope = new JTextPane();
		JTextPane scopeInfo = new JTextPane();
		scope.setText("Scope");
		scopeInfo.setText("Indicates a scope attachment.");
		
		eastPanel.add(direction);
		eastPanel.add(directionInfo);
		eastPanel.add(human);
		eastPanel.add(humanInfo);
		eastPanel.add(alien);
		eastPanel.add(alienInfo);
		eastPanel.add(pistol);
		eastPanel.add(pistolInfo);
		eastPanel.add(plasmacannon);
		eastPanel.add(plasmacannonInfo);
		eastPanel.add(chaingun);
		eastPanel.add(chaingunInfo);
		eastPanel.add(numbers);
		eastPanel.add(numbersInfo);
		eastPanel.add(stabilizer);
		eastPanel.add(stabilizerInfo);
		eastPanel.add(powerbooster);
		eastPanel.add(powerboosterInfo);
		eastPanel.add(scope);
		eastPanel.add(scopeInfo);
		
		mainPanel.add(westPanel);
		mainPanel.add(eastPanel);
		
		frame.add(mainPanel);
		frame.pack();
		frame.setVisible(true);
	}
}
