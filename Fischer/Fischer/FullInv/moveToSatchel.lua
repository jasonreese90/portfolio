function OnFullInventory()
 dropFish = {5455};

 numFish = table.getn(dropFish);

 blockInput(true)
 sendString("/satchel");
 sleep(200);
 sendKey(205);
 
 maxInv = getMaxInv();
 selectedIndex = 0;

 while selectedIndex ~= maXInv do
     setSelectedIndex(selectedIndex);
     selectedItem = getSelectedItemId();
     currentInv = getCurrentInv();

      for x = 0, numFish,1 do 
         if selectedItem == dropFish[x] then 
            sendKey(28);
          while getCurrentInv() ~= currentInv -1 do
             sleep(1);
          end;
            break;
         end;
      end;
 selectedIndex = selectedIndex + 1;
 sleep(2500);
 end;

blockInput(false)

if getMaxInv() == getCurrentInv() then 
 stop();
end;

end;