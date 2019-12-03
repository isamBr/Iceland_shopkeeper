Solution:Iceland_shopkeeper/Iceland_shopkeeper/Iceland_shopkeeper/
views : Iceland_shopkeeper/Iceland_shopkeeper/Iceland_shopkeeper/Views/
Model:Iceland_shopkeeper/Iceland_shopkeeper/Iceland_shopkeeper/Model



To debug the solution you need to install visual studio with xamarin .

if you want to install the package make sure your operatoor system in developer mode(UWP):
Iceland_shopkeeper\Iceland_shopkeeper\Iceland_shopkeeper.UWP\AppPackages\Iceland_shopkeeper.UWP_1.0.0.0_Test
Add-AppDevPackage

if you want to install the package in android:
Iceland_shopkeeper\com.companyname.iceland_shopkeeper.apk


Rules:
• All items have a SellIn value which denotes the number of days we have to sell the item
• All items have a Quality value which denotes how valuable the item is
• At the end of each day our system lowers both values for every item
• Once the sell by date has passed, Quality degrades twice as fast
• The Quality of an item is never negative
• The Quality of an item is never more than 50
• "Aged Brie" actually increases in Quality the older it gets
• “Frozen Item” decreases in Quality by 1
• "Soap" never has to be sold or decreases in Quality
• "Christmas Crackers", like “Aged Brie”, increases in Quality as its SellIn value approaches; Its
quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
but quality drops to 0 after Christmas
• "Fresh Item" degrade in Quality twice as fast as “Frozen Item”
Input: A list of items in the current inventory. Each line in the input represents an inventory item
with Item name, its sell-in value and quality e.g. “ Christmas Crackers -1 2” => Christmas Crackers
are past sellin value by 1 day with quality 2.
Output: Updated inventory after adjusting the quality and sellin days for each item after 1 day.






