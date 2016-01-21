### Restore Data
* Save the bakcup file: mysqldump -h localhost -u cbuser -p cookbook > cookbook.sql


### run script from cmd
* mysql cookbook < limbs.sql


### common script
* drop when object exists: ```DROP TABLE IF EXISTS limbs```;
