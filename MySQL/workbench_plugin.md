* a short introduction: http://dev.mysql.com/doc/workbench/en/wb-extending.html
* A sample maybe: http://blog.sqlstunts.com/2015/09/developing-mysql-workbench-plugin.html

### hints
* local samples: C:\Program Files\MySQL\MySQL Workbench 6.3 CE\modules
* some sample:  https://github.com/mysql/mysql-workbench/blob/aa9272c882eb9305f67890d177d70821cb5d28b3/plugins/wb.sqlide
  * root maybe: https://github.com/mysql/mysql-workbench/blob/aa9272c882eb9305f67890d177d70821cb5d28b3/plugins/wb.sqlide/sqlide_grt.py
* use relection: dir(class) .__func__, .__code__ to find 


### Things:
* how to add item to menu([P47] def handleLiveTreeContextMenu(name, sender, args):): https://github.com/mysql/mysql-workbench/blob/aa9272c882eb9305f67890d177d70821cb5d28b3/plugins/wb.sqlide/sqlide_schematree_ext.py
* Collect plugin's available input values: **select from here grt.root.wb.registry.plugins[0].inputValues**
* 
