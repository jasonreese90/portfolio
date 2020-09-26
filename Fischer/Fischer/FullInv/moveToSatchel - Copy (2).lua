function OnFullInventory()
 dropFish = {5455,4316};

 numFish = table.getn(dropFish);

 sendString("/satchel");
 sleep(200);
 sendKey(205);
 
 maxInv = getMaxInv();
 selectedIndex = 0;

 currentInv = getCurrentInv();

 for x = 0, numFish, 1 do
  fish = dropFish[x];

while getInvItemCount(fish) ~= 0 do

       next = nextInvItemIndex(fish);
       setSelectedItem(next):
       sendKey(28);
       while currentInv == getCurrentInv() do
          sleep(1);
       end;  
       sleep(1000); 
     
  end;
 end;

if getMaxInv() == getCurrentInv() then 
 stop();
end;

end;