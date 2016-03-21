### index type
* B-Tree(static structure+update)
* Hash
* [new] spatial indexes: for GIS data
* [new] full-text indexes use ```MATCH AGAINST```
* [extend] other types index

### index usage scenario

### advantage/disadvantage x concept level/implemntation level
* B-Tree : 
  * ad: sorting, can avoid fetch rows
  * disad: 
* Hash: can't use to sort, can't use range select
  * ad: very quick if no hash collisions
  * disad: 

### How to create and when to use which



### automatically create suitable index


### combine multiple index

### topics:
* in what kind of real world scenario will hashmap be very slow
  * select a bad hash function

* **adaptive hash indexes** in InnoDB Storage

* [P155: High performance Mysql 3nd] create hash value for you column as a new column, then use the new column with hash index.(use a trigger to generate the value)
  * what's the scenario for this approach, exact match 
  * since we have hash collision, we need to also specify the raw value in where expression or we will got multiple version
  * extend this method, we can calculate expression and store them in db column and setup up index on these columns! so we don't calcuate expression on query time
* index on long-length column
* hash shall be short for better performance
  * choose the hash function: CRC32, Part of MD5, your own value, FNV64() (shipped with Percona Server and can be installed as plugin)
  * 
