
function Test()
 start()
end

function OnFullInventory()
 dropFish = {4354,4379,4472,5455};

 numFish = table.getn(dropFish);

 setKey(29,true);
 sendKey(23);
 setKey(29,false);

 for i = 0, 10, 1 do  -- ensure we're at the top of item list
  sendKey(203);
 end;

 maxInv = getMaxInv();

 for i = 0, maxInv, 1 do
     selectedItem = getSelectedItemId();
     dropped = false;
      for x = 0, numFish,1 do 
      
         if selectedItem == dropFish[x] then 
            sendKey(28);
            sleep(200);
            sendKey(208);
            sleep(200);
            sendKey(28);
            sleep(200);
            sendKey(200);
            sleep(200);
            sendKey(28);
            dropped = true;
            maxInv = maxInv - 1;
            break;
         end;
       end;
       
       if dropped == false then
            sendKey(208);
       end;
    sleep(750);
 end;

if getMaxInv() == getCurrentInv() then 
 stop();
end;

end;