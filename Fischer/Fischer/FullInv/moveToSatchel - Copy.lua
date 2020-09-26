function OnFullInventory()
 dropFish = {5455};

 numFish = table.getn(dropFish);

 blockInput(true)
 sendString("/satchel");
 sleep(200);
 sendKey(205);
 
 maxInv = getMaxInv();
 invCount = getCurrentInv();

 for i = 0, maxInv, 1 do
     selectedItem = getSelectedItemId();
     dropped = false;

      for x = 0, numFish,1 do 
      
         if selectedItem == dropFish[x] then 
            sendKey(28);
            dropped = true;

            while invCount == getCurrentInv() do
                sleep(1);
            end;
            invCount = getCurrentInv();
            break;
         end;
       end;
       
       if dropped == false then
            sendKey(208);
       end;
 sleep(500);
 end;

blockInput(false)

if getMaxInv() == getCurrentInv() then 
 stop();
end;

end;